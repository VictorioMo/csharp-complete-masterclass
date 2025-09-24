# Clean Code – DRY Principle

The **DRY (Don't Repeat Yourself)** principle is one of the core ideas of clean code.  
It emphasizes reducing duplication in your codebase, making programs easier to maintain, extend, and debug.

---

## 🔹 What DRY Means
- **Don’t Repeat Yourself**: Every piece of knowledge, logic, or functionality should exist in *only one place* in your code.  
- Duplication leads to:
  - 🐛 Bugs (fixing in one place but forgetting the duplicate)  
  - 🔧 Harder maintenance  
  - 🐢 Slower development speed  

---

## 🔹 Benefits of DRY
- **Maintainability**: Update code once → changes apply everywhere.  
- **Readability**: Easier for others (and your future self) to understand.  
- **Reusability**: Common logic can be reused via functions, classes, or libraries.  
- **Scalability**: Cleaner architecture, easier to extend features.  

---

## 🔹 Examples

❌ **Without DRY (duplication):**
```csharp
double CalculateAreaOfCircle(double radius)
{
    return 3.14159 * radius * radius;
}

double CalculateCircumferenceOfCircle(double radius)
{
    return 2 * 3.14159 * radius;
}
```

✔ **With DRY (reuse constants / shared logic):**
```csharp
const double PI = Math.PI;

double CalculateAreaOfCircle(double radius) => PI * radius * radius;

double CalculateCircumferenceOfCircle(double radius) => 2 * PI * radius;
```

## 🔹 How to Apply DRY
- Extract common code into **functions** or **methods**  
- Use **constants** or **enums** for repeated values  
- Apply **OOP principles** like inheritance and interfaces  
- Refactor regularly to eliminate duplication  

---

## ⚠️ Common Pitfalls
While DRY is important, don’t **over-apply** it:
- Forcing abstraction too early can make code harder to read.  
- Sometimes **a little duplication is simpler** than a complex shared structure.  
- Focus on readability and maintainability over “perfect DRY.”  

---

## 📝 Summary
The DRY principle helps you write **cleaner, more maintainable code** by avoiding duplication.  
If you find yourself copy-pasting code, it’s often a sign that you should **refactor** and apply DRY.  
