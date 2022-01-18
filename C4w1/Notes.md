# Notes
## Contents
[Exceptions](#exceptions)

[File IO](#file-io)
  - [Streams](#streams)
  - [Text Files](#text-files)
    - [Writing To A File](#writing-to-a-file)
    - [Reading From A File](#reading-from-a-file)
  - [CSV Files](#csv-files)
    - [Reading CSV File On Unity](#reading-csv-file-on-unity)
  - [PlayerPrefs](#playerprefs)
    - [Getting Values](#getting-values)
    - [Setting Values](#setting-values)

## Exceptions
Exceptions are thrown when something bad happen in our code. This is of course still part of the basics, however, I will be pointing out about the `finally` block.

```csharp
try
{
    // code...
}
catch (Exception e)
{
    // code...
}
finally
{
    // always gets executed...
}
```

The `finally` block always gets executed regardless whether an exception occurred or not, however, what is then the point of using it? Can't we just not enclose the code after try-catch block?

```csharp
// So instead of:
try {}
finally {
    someCodeHere();
}

// We do:
try{}
someCodeHere();
```

The issue with the second approach would be that it is **NOT** guaranteed that it will always gets executed unlike with the `finally` block.

The example below is just one of many examples why a `finally` block is useful.

```csharp
void someFunction()
{
    try
    {
        // some code...

        if (someCondition)
        {
            return;
        }

        // some code...
    }
    finally
    {
        // THIS will get executed regardless of whether
        // we got to return abruptly
    }
}
```

## File IO
### Streams
Data flows into and out of streams. Examples of streams are the input stream used by the `Console.ReadLine()` method and the output stream used by the `Console.WriteLine()` method.\
The `Console.ReadLine()` gets its input from the keyboard while the `Console.WriteLine()` outputs its data to the console. However, we can also make it so they receive their inputs and they do their outputs elsewhere, and this is where files come in.

Using files let us persist data so it does not get destroyed/erased after the game ends/exits.

### Text Files
To write to a text file, we use `StreamWriter` and its method `WriteLine`, and to read from a file, we use `StreamReader` and its method `ReadLine`. We create a file using `File.CreateText(<filename>)` and we open a file using `File.OpenText(<filename>)`.

#### Writing To A File
```csharp
StreamWriter output = null;
try
{
    // open file
    output = File.CreateText(fileName);

    // write to file
    output.WriteLine(someTextToWrite);
}
catch (Exception e)
{
    // print out error message to console
    Console.WriteLine(e.Message);
}
finally
{
    // close file
    if (output != null)
    {
        output.Close();
    }
}
```

#### Reading From A File
```csharp
StreamReader input = null;
try
{
    // open file
    input = File.OpenText(fileName);

    // read file
    string line;
    while ((line = input.ReadLine()) != null)
    {
        // do something with the line
    }
}
catch (Exception e)
{
    // print out error message to console
    Console.WriteLine(e.Message);
}
finally
{
    // close file
    if (output != null)
    {
        output.Close();
    }
}
```

### CSV Files
Sometimes we want to have a configuration file that we can modify to apply patches or for game designers/players to be able to change how the game behaves without modifying the source code.\
This configuration file can come to different types but the most common are `.csv` and `.xml` (or eXtensible Markup Language).

#### Reading CSV File On Unity
The code below shows how we might read configuration data saved on a `.csv` file.

```csharp
/// <summary>
/// Constructor
/// Reads configuration data from a file.
/// </summary>
public ConfigurationData()
{
    // read and save configuration data from file
    StreamReader input = null;
    try
    {
        // open file
        input = File.OpenText(Path.Combine(
            Application.streamingAssetsPath, ConfigurationDataFileName));

        // read header and values
        // assuming there are no more than 2 rows
        string header = input.ReadLine();
        string values = input.ReadLine();

        // set configuration data fields
        SetConfigurationDataFields(values);
    }
    catch (Exception ex)
    {
        // output error message
        MonoBehaviour.print(ex.Message);
    }
    finally
    {
        // close file if open
        if (input != null)
        {
            input.Close();
        }
    }
}


/// <summary>
/// Sets the configuration data fields from the provided
/// csv string
/// </summary>
/// <param name="csvValues">csv string of values</param>
static void SetConfigurationDataFields(string csvValues)
{
    // get each data from row
    string[] values = csvValues.Split(',');

    // assign fields
    // assuming we know and use the same ordering on the values
    fieldA = float.Parse(values[0]);
    fieldB = float.Parse(values[1]);
    // ...
    fieldN = float.Parse(values[<someNumber>]);
}
```

> If we tried to change our .csv config file and we did not close the application we used to change the data then we tried to run the game, we will get an error `Sharing violation on path <path>`, it is because what it says, another application is _sharing_ the same path, so make sure to close the program we used to modify the config file first before we run the game.

### PlayerPrefs
`PlayerPrefs` let us store data across game sessions.

#### Getting Values
```csharp
// get string from PlayerPrefs
string str = PlayerPrefs.GetString(<key>);
```

`<key>` is a string. If the `<key>` provided does not exists, `PlayerPrefs.GetString` returns an empty string or `""`.

#### Setting Values
```csharp
PlayerPrefs.SetString(<key>, <value>);
PlayerPrefs.Save();
```

Both `<key>` and `<value>` are strings, and we call the `PlayerPrefs.Save` method because the changes we make in `PlayerPrefs` will only be saved after the application quits so to "force" save, we use that. It has something to do with performance why they made it that way and also the caveat with NOT using the save method is when our application crashes, we won't have the data we wanted to save saved.

> On Windows, the values in `PlayerPrefs` gets saved in the registry, namely, go to the **HKEY_CURRENT_USER** folder then to **Software**, then to the game's company name and the name of the game. (This is when the game is built and not in run in the editor, if otherwise we run the game in the editor, it is then saved still under **Software** but now we need to go under **Unity** then **UnityEditor** then the game company's name and the name of the game.)
