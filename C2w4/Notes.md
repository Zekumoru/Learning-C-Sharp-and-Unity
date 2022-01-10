# Notes
## Dynamic-link Library (DLL)
A _.dll_ is useful if we want others to use our code but we do not want to show them the source code.

### Adding A .DLL File
- Put the _.dll_ file into the project folder
- Back in Visual Studio, right-click **Dependencies** then select `Add Project Reference`
- Click `Browse...`, navigate to project folder, select the _.dll_ file then click `Add`
- Click `OK`

### Using The .DLL File
We need to declare a `using` directive to be able to use the classes and methods inside the _.dll_ file.

```csharp
using NameOfTheDLLFile;
```

### Incompatible Framework Error
If it so happens that the _.dll_ we wanted to use targets a framework higher than the current framework we are using. (For example, our program uses the **.NET 5.0** framework but the _.dll_ file uses the **.NET 6.0** framework)/
Then we must change to the newer framework if we were to use that _.dll_

To change framework, we do...
- Right-click the project name in the **Solution Explorer** in Visual Studio
- Select `Properties`
- Go under **Target framework** then click the drop-down menu to select your desired target framework

> If you are using multiple .DLLs and they all target different frameworks, to be able to use them all, we simply change our target framework to the highest framework.
