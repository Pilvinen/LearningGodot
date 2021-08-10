using Godot;
// ReSharper disable ArrangeAccessorOwnerBody
// ReSharper disable MemberCanBePrivate.Global

namespace LearningGodot {
    
    // This example shows lazy initialization of properties.
    // *****************************************************
    // Lazy initialization can be used in situations where you want to have the property value initialized - not right
    // from the start, but only after it's actually being used.
    // The value of the property is initially null.
    // When the value is being accessed for the first time then, and only then, it gets its value.
    // After the property's value has been assigned it will hold its value normally.
    
    public class LazyInitialization : Node {
        
        // Example 1: Declaring a lazy property initializer.
        // *************************************************
        
        // Private backing field for holding the data.
        private Label? _backingFieldForLazyValue1;

        // Public property for accessing the private backing field above. Expression bodied. Getter only.
        public Label MyPropertyForLazyValue1 => _backingFieldForLazyValue1 ??= GetNode<Label>("ExampleLabel");

        // That's it.
        
        // The rest of the code and comments below are just for show and tell to explain and showcase
        // what is happening here.
        
        // Breakdown of the property declaration above:
        // - Value is assigned to the property "MyPropertyForLazyValue1" via an expression body "=>".
        // - The property receives only a getter because of the short hand expression bodied syntax.
        // What the expression right of the fat arrow "=>" does is:
        // - "If _backingFieldForLazyValue is not null, return the value assigned in the backing field."
        // - "Else the _backingFieldForLazyValue is null, run the expression: GetNode<Sprite<("MySprite") and
        // 1) Assign the value of the expression to _backingFieldForLazyValue.
        // 2) Finally, return the value.

        
        // Example 2: Declaring a lazy property initializer.
        // *************************************************
        
        // Private backing field for holding the data.
        private Label? _backingFieldForLazyValue2;

        // Public property for accessing the private backing field above. Expression bodied. Getter and setter.
        public Label MyPropertyForLazyValue2 {
            get => _backingFieldForLazyValue2 ??= GetNode<Label>("ExampleLabel");
            set => _backingFieldForLazyValue2 = value;
        }

        
        // Example 3: Declaring a lazy property initializer.
        // *************************************************
        // For clarity, below is exactly the same thing as above in example 2, but WITHOUT the expression bodied format.
        
        // Private backing field for holding the data.
        private Label? _backingFieldForLazyValue3;
        
        // Public property for accessing the private backing field above. Expression bodied. Getter and setter.
        public Label MyPropertyForLazyValue3 { 
            get {
                return _backingFieldForLazyValue3 ??= GetNode<Label>("ExampleLabel");
            }
            set {
                _backingFieldForLazyValue3 = value;
            }
        }

        
        // Example 4: Accessing the property.
        // **********************************
        // Below is a method which shows the properties being accessed.
        public void DoSomething() {

            // Lets set a nicer console color for fun.
            System.Console.ForegroundColor = System.ConsoleColor.Green;

            if (_backingFieldForLazyValue2 is null) {
                var myMessage = "1) _backingFieldForLazyValue2 is null before accessing the property MyPropertyForLazyValue2.";
                // System.Console.WriteLine(myMessage);
                GD.Print(myMessage);
            } else {
                // Red color for error.
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                var myMessage = "1) ERROR: _backingFieldForLazyValue2 is NOT null before accessing the property MyPropertyForLazyValue2!";
                // System.Console.WriteLine(myMessage);
                GD.Print(myMessage);
            }
            
            // Lets reset the color back to green in case we changed it in the if-statement.
            System.Console.ForegroundColor = System.ConsoleColor.Green;

            // MyPropertyForLazyValue is initially null so GetNode is called and the property gets initialized
            // by calling the expression with GetNode and then the value gets assigned to myValue.
            var myMessage2 = $"2) MyPropertyForLazyValue2.Text contains the text: \"{MyPropertyForLazyValue2.Text}\"";
            // System.Console.WriteLine(myMessage2);
            GD.Print(myMessage2);
            
            // The second time the property is accessed it has already been initialized and its value gets
            // assigned to myValueCopy directly without any further initialization.
            if (!(_backingFieldForLazyValue2 is null)) {
                var myMessage3 = "3) _backingFieldForLazyValue2 is NOT null after accessing the property MyPropertyForLazyValue2.";
                // System.Console.WriteLine(myMessage3);
                GD.Print(myMessage3);
            } else {
                // Red color for error.
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                var myMessage3 = "3) ERROR: _backingFieldForLazyValue2 is null after accessing the property MyPropertyForLazyValue2!";
                // System.Console.WriteLine(myMessage3);
                GD.Print(myMessage3);
            }
        }
        
        // NOTE: Initialization order must be respected when calling the property for the first time.
        // NOTE: For example: You cannot call the property before it's possible for GetNode to get the value.


        public override void _Ready() {
            System.Console.ForegroundColor = System.ConsoleColor.White;

            GD.Print();
            GD.Print("-----");
            var myMessage4 = "LazyInitialization example running...";
            // System.Console.WriteLine(myMessage4);
            GD.Print(myMessage4);

            // Run the example.
            DoSomething();
            
            System.Console.ForegroundColor = System.ConsoleColor.White;

            GD.Print("-----");

        }
    }
    

}
