this app helps a developer to create a module to extend the Plang programming language.

This app will generate a Program.cs file, as a starting point for your module. It will include nuget packages if needed.

## Example of usage ##

Here is an example of user creating EmailModule:
Start by giving it a name: EmailModule
Write a description for it: Send and receive email using smtp and pop3.

example of plang code could be
- send email \%to\%, \%subject\%, \%body\%
- get new emails, write to \%emails\%

This will create a Program.cs file in the module folder as well as a C# project file

## Example of usage ##

Use the above example when generating README file 

This app is meant to be a starting point for developers, don't expect to have a fully functional module working, you probably need to modify it to fit you need.