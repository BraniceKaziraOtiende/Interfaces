# Unity Interface Assignment — Shape Testing 🎮📐

A beginner-friendly Unity project that shows how C# interfaces work in practice.  
We created one shared contract (`IShape`) and let three very different shapes sign it: **Trapezium**, **Circle**, and **Nonagon**.  
The result? 100 % reusable code, zero drama, and pretty console output.

---

## ✨ What You’ll Learn

* How to define and implement an interface in Unity  
* Polymorphism without inheritance headaches  
* Clean console feedback with `Debug.Log()`  
* Tiny math tricks (Pythagoras, π, and 9-sided polygons)

---

## 📁 Project Structure
InterfaceAssignment/
├── Assets/
│   └── Scripts/
│       └── Interfaces/
│           ├── IShape.cs
│           ├── Trapezium.cs
│           ├── Circle.cs
│           ├── Nonagon.cs
│           └── InterfaceTestScript.cs   ← press Play and watch the console
├── ProjectSettings/
├── Packages/
├── .gitignore
└── README.md
Copy

---

## 🔍 The Interface (IShape)

One small contract keeps every shape honest:

```csharp
public interface IShape
{
    void CalculateArea();
    void CalculatePerimeter();
}
🟦 Shape Classes
Table
Copy
Shape	Bonus Method (shows class-specific power)
Trapezium	CalculateUnknownSides() – uses Pythagoras to find missing sides
Circle	CalculateRadius() – derives radius from any given area
Nonagon	CalculateNumberOfSides() – always returns 9, but proves a point
🧪 Sample Console Output
Copy
====================================
INTERFACE ASSIGNMENT - SHAPE TESTING
====================================

=== TRAPEZIUM ===
Trapezium - Calculated Unknown Sides: Side C = 5.00, Side D = 5.00
Trapezium - Area: 32.00 square units
Trapezium - Perimeter: 26.00 units

=== CIRCLE ===
Circle - Calculated Radius: 7.00 units
Circle - Area: 154.00 square units
Circle - Perimeter (Circumference): 43.98 units

=== NONAGON ===
Nonagon - Number of Sides: 9
Nonagon - Area: 155.21 square units
Nonagon - Perimeter: 45.00 units

ALL TESTS COMPLETED SUCCESSFULLY!
====================================

🚀 Getting Started
Clone the repo
bash
Copy
git clone https:https://github.com/BraniceKaziraOtiende/UnityEssentials.git


Open the folder with Unity Hub (2019 LTS or newer).
Double-click InterfaceTestScript.cs if you want to peek inside.
Hit Play and read the Console. That’s it—no scene setup required!


🤝 Contributing
Found a typo or a cooler formula? Pull requests are welcome.