# Arduino2Unity

## Opsætning
### Smid scriptet ind i din assets mappe

### Skift til .NET 2.0
Unity -> Edit -> Project Settings -> Player
Other Settings -> Configuration -> .NET 2.0 Subset skiftes til .NET 2.0

### For at bruge scriptet:
Opret et nyt C# script hvor du instantierer singleton objektet ArduinoCommunication:

ArduinoCommunication arduinoCommunication = new ArduinoCommunication();

For at frigive serielportens tråd skal du huske at tilføje en funktion:

void OnApplicationQuit(){
    arduinoCommunication.StopThread();
}

Skrevet af Asger Roed (@asgerr)
