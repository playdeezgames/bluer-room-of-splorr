rm -rf ./pub-html
dotnet publish ./src/BROS.Blazor/BROS.Blazor.csproj -o ./pub-html -c Release 
rm -f ./pub-html/*.pdb
butler push pub-html/wwwroot thegrumpygamedev/the-bluer-room-of-splorr:html
