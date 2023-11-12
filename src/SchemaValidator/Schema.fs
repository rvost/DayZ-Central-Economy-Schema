module SchemaValidator.Schema
open GlobExpressions

let private (|Pattern|_|) (pattern: string) input =
    if Glob.IsMatch(input, pattern, GlobOptions.CaseInsensitive) then
        Some()
    else
        None

let resolveXsd (path: string) =
    match path with
    | Pattern "**/cfgeconomycore.xml" -> Some("cfgeconomycore.xsd")
    | Pattern "**/cfgenvironment.xml" -> Some("cfgenvironment.xsd")
    | Pattern "**/cfgeventgroups.xml" -> Some("cfgeventgroups.xsd")
    | Pattern "**/cfgeventspawns.xml" -> Some("cfgeventspawns.xsd")
    | Pattern "**/cfgignorelist.xml" -> Some("cfgIgnoreList.xsd")
    | Pattern "**/cfglimitsdefinition.xml" -> Some("cfglimitsdefinition.xsd")
    | Pattern "**/cfglimitsdefinitionuser.xml" -> Some("cfglimitsdefinitionuser.xsd")
    | Pattern "**/cfgplayerspawnpoints.xml" -> Some("cfgplayerspawnpoints.xsd")
    | Pattern "**/cfgrandompresets.xml" -> Some("cfgrandompresets.xsd")
    | Pattern "**/cfgspawnabletypes.xml" -> Some("cfgspawnabletypes.xsd")
    | Pattern "**/cfgweather.xml" -> Some("cfgspawnabletypes.xsd")
    | Pattern "**/mapclusterproto.xml" -> Some("mapclusterproto.xsd")
    | Pattern "**/mapgroupcluster*.xml" -> Some("mapgroupcluster.xsd")
    | Pattern "**/mapgroupdirt.xml" -> Some("mapgroupdirt.xsd")
    | Pattern "**/mapgrouppos.xml" -> Some("mapgrouppos.xsd")
    | Pattern "**/mapgroupproto.xml" -> Some("mapgroupproto.xsd")
    | Pattern "**/db/economy.xml" -> Some("db/economy.xsd")
    | Pattern "**/db/events.xml" -> Some("db/events.xsd")
    | Pattern "**/db/globals.xml" -> Some("db/globals.xsd")
    | Pattern "**/db/messages.xml" -> Some("db/messages.xsd")
    | Pattern "**/types*.xml" -> Some("db/types.xsd")
    | Pattern "**/env/*.xml" -> Some("env/territories.xsd")
    | _ -> None
