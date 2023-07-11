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

Validating such rules requires more effort than using a common text editor and an XSD file. It can be done with an extension. I'm currently considering writing a VS Code extension for comprehensive editing of DayZ CE files. I'm not sure as there are already many different tools for this. Please let me know if you are interested.

### Alternative solution

If you prefer a more high-level approach and spreadsheet-like editing rather than digging into XML files, have a look at my [DayzServerTools](https://github.com/rvost/DayzServerTools). In fact, this repository is part of an effort to provide comprehensive validation in the DayzServerTools.