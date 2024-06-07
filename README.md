# DayZ Central Economy Schema

## Problem

Tweaking the [DayZ Central Economy](https://github.com/BohemiaInteractive/DayZ-Central-Economy) configuration can sometimes be daunting, due to the complex structure of the config files, the size of the files, and the usually strange behaviour of the CE engine in case of misconfiguration.
Limited official documentation on CE also adds to the problem. 

The error rate can be greatly reduced by using appropriate tools such as editors with XML support. Many editors support validation of XML files against XSD (XML Schema Definition), but unfortunately there is no official schema.

## Solution 

This repository aims to provide an **unofficial** XSD schema along with some documentation that  can be used to:

- Validate CE files;
- Improve the editing experience - many editors support auto-completion and hints for XML when provided with a schema;
- Improve understanding of CE configuration files;
- Generate data structures in your programming language of choice if you are developing custom tools for CE.

### Limitations

Please note that while validating against a schema can eliminate syntax errors and catch many errors that are limited to one file, *it can't help with errors that span multiple files*, such as using a category in `types.xml` that is not defined in `cfglimitsdefinition.xml`.

Validating such rules requires more effort than using a common text editor and an XSD file.

> [!TIP]
> It can be done in VS Code (or any Code-based editor like [VSCodium](https://vscodium.com/)) using an [extension](https://marketplace.visualstudio.com/items?itemName=rvost.dayz-ce-schema). You can find more about the extension in the [repo](https://github.com/rvost/dayz-ce-schema).

### Alternative solution

If you prefer a more high-level approach and spreadsheet-like editing rather than digging into XML files, have a look at my [DayzServerTools](https://github.com/rvost/DayzServerTools). In fact, this repository is part of an effort to provide comprehensive validation in the DayzServerTools.

## How to

### VS Code

1. Install the [XML extension](https://marketplace.visualstudio.com/items?itemName=redhat.vscode-xml).
2. Open an XML file that you want to validate, press `F1`` or `Ctrl+Shift+P`` and select *XML:Bind to grammar/schema file* command.
 You have the option of using a local or remote schema.
 I recommend that you use the latter as your schema will be updated automatically. 
   - If you choose to use local schema you need to download (or clone) this repository and provide local path to corresponding .xsd file
   - For convenience, all schemas are available online (thanks to Github Pages) at `https://rvost.github.io/DayZ-Central-Economy-Schema/`. So for remote option you provide path starting from this address, e.g. `https://rvost.github.io/DayZ-Central-Economy-Schema/db/types.xsd` for types schema or `https://rvost.github.io/DayZ-Central-Economy-Schema/cfgeventspawns.xsd` for events.
3. I recommend using the *File Association* option because it works without editing the original xml file.
4. Repeat this process for each file you want to validate **OR** the take `.vscode/settings.json` file from this repo and copy it to your workspace with all associations already set up.

### Notepad++

1. Install the [XML Tools](https://github.com/morbac/xmltools) plugin (you can follow [this](https://stackoverflow.com/questions/15436183/using-notepad-to-validate-xml-against-an-xsd) tutorial on SO).
2. Open XML file and press `Ctrl+Shift+Alt+M` (or use Menu if this is your preference `Plugins > XML Tools > Validate Now`) and enter corresponding schema URL (as described above).
3. Repeat this process for each file you want to validate.
  
You can also reference schema in XML file like this 
```xml
<spawnabletypes xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' 
  xsi:noNamespaceSchemaLocation="<URL here>">
    ...
</spawnabletypes>
```
to avoid having to specify XSD location for every validation.

## Contributing

I hope this schema is good enough to be useful but it is by no means complete or exhaustive. 
So if you find a problem (errors it can't detect or false positives, etc.) please let me know via [Issues](https://github.com/rvost/DayZ-Central-Economy-Schema/issues) or if you can fix it yourself, don't be shy to submit a PR!
