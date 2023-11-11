open System.IO
open System.Xml
open System.Xml.Schema
open System.Xml.Linq
open SchemaValidator.Schema

let load (path: string) =
    try
        let doc = XDocument.Load(path, LoadOptions.SetBaseUri ||| LoadOptions.SetLineInfo)
        Ok(doc)
    with ex ->
        Error([| ex.Message |])

let validate (schema: XmlSchemaSet) (doc: XDocument) =
    let errors = ResizeArray<string>()

    let handler (sender:obj) (args: ValidationEventArgs) =
        let lineInfo = sender :?> IXmlLineInfo
        errors.Add($"{args.Severity}: {args.Exception.Message} [Ln {lineInfo.LineNumber} Col {lineInfo.LinePosition}]")

    doc.Validate(schema, handler)

    if errors.Count = 0 then
        Ok(doc)
    else
        Error(errors.ToArray())

let validateXsd (xsdLoader) (doc: XDocument) =
    match resolveXsd (doc.BaseUri) with
    | Some schema -> validate (xsdLoader (schema)) doc
    | None -> Error([| $"Schema not found for {doc.BaseUri}" |])

let processFile (xsdLoader) (filePath: string) =
    let result = filePath |> load |> Result.bind (validateXsd xsdLoader)

    match result with
    | Ok _ ->
        printfn "%s successfully validated" filePath
        0
    | Error errors ->
        printfn "Errors in %s" filePath
        Seq.iter (printfn "\t%s") errors
        errors.Length

let localXsdLoader (xsdRoot: string) (path: string) =
    let schemaSet = XmlSchemaSet()
    let fullPath = Path.Combine(xsdRoot, path)
    schemaSet.Add(null, XmlReader.Create(fullPath)) |> ignore
    schemaSet

[<EntryPoint>]
let main argv =

    let directoryPath = Array.head argv
    let schemaRoot = argv |> Array.tryItem 1 |> Option.defaultValue "./schema"

    let xmlFiles =
        Directory.EnumerateFiles(directoryPath, "*.xml", SearchOption.AllDirectories)

    let xsdLoader = localXsdLoader schemaRoot

    let errors = xmlFiles |> Seq.map (processFile xsdLoader) |> Seq.sum

    errors
