# Html-to-C#
Module that Parses Html and converts it to C# objects

## Usage

```C#
string content = ContentProvider.getContentAsync();
            HtmlParser parser = new HtmlParser(content);
            List<HtmlObject> Webpage = parser.Parse();
```

## Usage
Requirement : Microsoft .Net Core 5 

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to test updates as appropriate.

## License
GNU General Public License v3.0
