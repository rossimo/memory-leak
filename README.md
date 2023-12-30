# memory-leak

Built against Godot 4.2.1 .NET

```cs
dotnet restore
dotnet build
godot
```

Start app, then use the arrow keys to move the sprite around.  The memory leak will be reported in the console when the app is closed.

```pwsh
PS C:\Users\rosss\Documents\Memory Leak> godot
Godot Engine v4.2.1.stable.mono.official.b09f793f5 - https://godotengine.org
Vulkan API 1.3.260 - Forward+ - Using Vulkan Device #0: NVIDIA - NVIDIA GeForce RTX 2060 SUPER
 
ERROR: 451 RID allocations of type 'N18RendererCanvasCull4ItemE' were leaked at exit.
WARNING: ObjectDB instances leaked at exit (run with --verbose for details).
     at: cleanup (core/object/object.cpp:2208)
```