# CSBulkRenamer

A bulk rename utility written in c# for the command line. 

CSBulkRenamer reads in the contents of a directory into a plain text file that a user can edit. Using a powerful editor such as VSCode or vim could allow a user to easily rename multiple lines in the text file. After editing the text file is done, CSBulkRenamer uses the text file to rename the files in the given directory. 

## Usage

```
CSBulkRenamer 1.0.0.0
Copyright c  2020

  -c, --command          (Default: createTempFile) Which Command you want to run
                         [createTempFile | rename]

  -t, --tempFile         (Default: files.txt) Path to where your files.txt file
                         is

  -d, --directoryPath    (Default: .) Path to the directory that contains all
                         the files you want to rename

  --help                 Display this help screen.

  --version              Display version information.

```