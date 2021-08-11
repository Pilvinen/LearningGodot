# Learning Godot and C#

I will gather Godot and C# scripting examples along with Godot best practices (from my perspective) and other usage tips here. Learn, practice, and test! Everything will be under one Godot project for convenience. Each example will be separated into a self-contained scene. Each example will be well commented.

Functional programming practices and data oriented design will be emphasized when possible. Loose coupling and abstraction will be design goals. Example code will be isolated and separated from Godot when practical.

All in all the goal is to use real world - useful - practices and examples where real game design challenges, code architecture, and code structure are addressed.

# Contents

## Lazy initialization
Lazy initialization can be used in situations where you want to have property value initialized - not right from the start - but rather when it is being accessed for the first time.
```c#
private Label? _backingFieldForLazyValue1;
public Label MyPropertyForLazyValue1 => _backingFieldForLazyValue1 ??= GetNode<Label>("ExampleLabel");
```
See project example for full details.
