# 🧾 Reserved Characters in C#

In C#, certain characters are **reserved** because they play specific roles in the syntax of the language.  
You **don’t need to memorize** all of them — this is simply an overview for reference.

---

## 🔣 List of Reserved Characters and Their Usage

### 🔹 `{ }` – Braces
- Define **scope or code blocks** (methods, loops, if statements, classes)

---

### 🔹 `( )` – Parentheses
- Used for **method calls**, **conditions** (`if`, `while`, `for`)
- Control **order of operations** in expressions

---

### 🔹 `[ ]` – Square Brackets
- Declare and access **arrays**
- Used in **attributes**

---

### 🔹 `;` – Semicolon
- Ends a **statement**

---

### 🔹 `:` – Colon
- Used in:
  - **Ternary operator** (`condition ? a : b`)
  - **`switch` case** labels
  - **Base class/interface** inheritance (`class Dog : Animal`)

---

### 🔹 `,` – Comma
- Separates:
  - Parameters
  - Values
  - Variables in declarations

---

### 🔹 `.` – Period
- Accesses **members** of a class/namespace (e.g., `Console.WriteLine`)

---

### 🔹 `?` – Question Mark
- Nullable types (`int?`)
- Null-conditional operator (`user?.Name`)
- Ternary operator (`condition ? value1 : value2`)

---

### 🔹 `+` – Plus
- Addition, **string concatenation**, **unary plus**, operator overloading

---

### 🔹 `-` – Minus
- Subtraction, **negation**, operator overloading

---

### 🔹 `*` – Asterisk
- Multiplication, **pointer types** (unsafe code), operator overloading

---

### 🔹 `/` – Slash
- Division  
- Starts **comments**: `//` and `/* ... */`

---

### 🔹 `%` – Percentage
- **Modulus** operator (remainder after division)

---

### 🔹 `&` – Ampersand
- Bitwise AND, logical AND  
- **Reference parameter** indicator (`ref`, `out`)

---

### 🔹 `|` – Pipe
- Bitwise OR, logical OR

---

### 🔹 `^` – Caret
- **Bitwise XOR** (exclusive OR)

---

### 🔹 `!` – Exclamation Mark
- **Logical NOT** (negation)

---

### 🔹 `~` – Tilde
- Bitwise NOT  
- Used for **destructor declarations**

---

### 🔹 `< >` – Angle Brackets
- Used in:
  - **Generic type definitions** (e.g., `List<int>`)
  - **Comparison operators** (`<`, `>`)

---

### 🔹 `=` – Equals
- Assignment (`=`)  
- Comparison (`==`)  
- Used in **lambda expressions** (`=>`)

---

### 🔹 `@` – At Sign
- Marks:
  - **Verbatim strings** (`@"C:\path\file.txt"`)
  - **Escaped keywords** (`@class`, `@string`)

---

### 🔹 `$` – Dollar Sign
- **String interpolation** (`$"Hello, {name}"`)

---

### 🔹 `\` – Backslash
- **Escape character** in strings (`\n`, `\t`, `\\`)

---

### 🔹 `#` – Hash / Pound
- Used in **preprocessor directives**:
  - `#define`
  - `#if`, `#else`, `#endif`
  - `#region`, `#endregion`

---

## 📌 Summary

These characters are reserved for specific uses in the C# language.  
Using them outside their role may lead to compiler errors unless **escaped** or **used in special contexts**.  
Understanding them will make your code cleaner, more readable, and less error-prone.

> 🧠 Don’t worry if you don’t recognize all of them yet — you’ll naturally learn them as you write more C#!

