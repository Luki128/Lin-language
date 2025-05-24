# Lin – a tiny interpreted language

> **Lin** (pronounced /lɪn/) is a *very simple but surprisingly powerful* expression-language interpreter written in pure C#.  The entire core fits into a single file, making it easy to read, modify and extend.  Think of it as a friendly playground for experimenting with parsing, evaluation and simple language design.

---

## ✨  Key facts

| Property            | Value                        |
| ------------------- | ---------------------------- |
| **Current version** | 0.1.0 (first public drop)    |
| **Code size**       | \~500 LOC including comments |
| **Dependencies**    | .NET 6 runtime *only*        |
| **License**         | MIT                          |

*Lin is intentionally minimal – it can (and should!) be improved, but its current form is fully functional and **fast to implement**.*

---

## 📦 Building & running

```bash
# Clone & build
$ git clone https://github.com/your-org/lin.git
$ cd lin
$ dotnet build -c Release

# Launch the REPL
$ dotnet run --project Lin
> print("Hello, Lin!")
Hello, Lin!
(ok)
```

> **Tip :** Any C#‑10/11 compatible runtime (e.g. .NET 6, .NET 7) will work – no external NuGet packages are required.

---

## 🏁 Quick language tour

### Variables & arithmetic

```text
x = 2 * 3 + 1   # => 7
hex = 0xFF       # hexadecimal literals are fine, too
```

### Built‑in operators

| Category   | Operators                        |
| ---------- | -------------------------------- |
| Arithmetic | `+`, `-`, `*`, `/`, `%`          |
| Bitwise    | `&`, `\|`, `^`, `<<`, `>>`       |
| Comparison | `<`, `<=`, `>`, `>=`, `==`, `!=` |

All operators work on 64‑bit signed integers.  String concatenation is supported with `+`.

### Functions

User‑defined functions use the `fun` keyword:

```text
fun square(n) {
    return n * n;
}

print(square(12))   # => 144
```

Built‑in helpers live in a dictionary – add your own in one line of C#!

### Control flow

```text
if (x > 0) {
    print("positive");
} else {
    print("non‑positive");
}

for (i = 0; i < 5; i = i + 1) {
    print(i);
}
```

---

## 🔌 Extending Lin

Lin’s core is purposely short and readable.  To add new features you typically only need to touch **one place**:

* **New built‑in function** – register a lambda in `buildinFunctions`.
* **New operator** – add a case to `ApplyOperator` and update precedence in `IsOperatorWithPrecedence`.
* **New statement** – add a branch inside `ParseStatement` and implement a helper similar to `ExecIfStatement`.

Because everything is interpreted, changes are picked up immediately at runtime – no extra tooling is required.

---

## 🧩 Embedding Lin for user automation

Need a scripting layer so users can automate your app?  **Lin** is small enough to drop directly into any .NET solution:

1. Copy **LinInterpreter.cs** into your project.
2. Expose your own API by injecting custom built‑ins (one line each).
3. Launch the REPL or evaluate scripts programmatically.

Your users gain the ability to write *macros, small tools and batch jobs* without you building a dedicated UI up front – and you stay in full control of the exposed surface.

---

## 🛣️ Roadmap / Ideas

* Better error reporting (line/column numbers)
* Unary operators `-` and `+`
* `while` loops and `break` / `continue`
* Simple module / import system
* 64‑bit floating‑point numbers

Pull requests & suggestions are welcome!

---

## 📚 Background & motivation

Lin began as a **fast‑implementation** challenge: how quickly can we assemble a usable interpreter with modern C# and as few lines as possible?  The answer – surprisingly quickly!  The result is a compact, portable playground ideal for:

* Teaching the basics of parsing and interpretation
* Embedding a lightweight scripting layer into a bigger .NET project
* Rapid prototyping of language features without a heavyweight toolchain

---

## © License

Released under the [MIT License](LICENSE).  Feel free to use, modify and distribute.
