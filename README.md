# design-patterns

# Патерн Abstract Factory

## Опис

**Abstract Factory** — це шаблон проєктування, який дозволяє створювати родини пов’язаних або залежних об’єктів без прив’язки до конкретних класів. Інакше кажучи, він інкапсулює створення групи взаємопов’язаних продуктів, щоб клієнтський код міг їх використовувати, не знаючи їх конкретних реалізацій.

Цей підхід ідеально підходить, коли в системі має бути забезпечена взаємозамінність груп об’єктів та дотримання принципу **відкритості/закритості** (*Open/Closed Principle*).

## Структура

- **AbstractFactory** — інтерфейс для створення абстрактних продуктів.
- **ConcreteFactory** — реалізація фабрики, яка створює конкретні продукти.
- **AbstractProduct** — інтерфейс для абстрактного продукту.
- **ConcreteProduct** — реалізація продукту.
- **Client** — використовує тільки інтерфейси, не залежить від конкретних класів.

## Переваги

- Ізоляція конкретних класів
- Забезпечує узгодженість продуктів
- Дотримується принципу інверсії залежностей

## Недоліки

- Додаткове ускладнення коду через велику кількість інтерфейсів та класів
- Важче додавати нові продукти в уже наявну фабрику

```mermaid
classDiagram
direction LR
Client --> AbstractFactory
Client --> AbstractProduct
AbstractFactory <|-- ConcreteFactory
AbstractProduct <|-- ConcreteProductA
AbstractProduct <|-- ConcreteProductB
ConcreteProductA <.. ConcreteFactory : creates
ConcreteProductB <.. ConcreteFactory : creates

  class Client {
  }
  class AbstractFactory{
    +CreateProductA()
    +CreateProductB()
  }
class ConcreteFactory{
    +Create productA()
    +Create productB()
  }
  class AbstractProduct{
  }
```

```mermaid
sequenceDiagram
  participant Client as :Client
  participant AbstractFactory as factory: Factory1
  participant ProductA as pa1: ProductA1
  participant ProductB as pb1: ProductB1

  Client ->>+ AbstractFactory: create ProductA()
  AbstractFactory ->>- ProductA: new
  AbstractFactory -->> Client: return pa

  Client ->>+ AbstractFactory: create ProductB()
  AbstractFactory ->>- ProductB: new
  AbstractFactory -->> Client: return pb
```
# Патерн Facade

## Опис

**Facade** —  це структурний патерн, який надає простий (але урізаний) інтерфейс до складної системи об’єктів, бібліотеки або фреймворку.

## Структура

- **Facade** — клас, який надає простий інтерфейс до складної підсистеми. Делегує запити до відповідних об’єктів підсистем.
- **Subsystem classes (підсистема)** — кілька класів, які реалізують складну логіку. Вони не знають про існування фасаду і працюють самостійно.
- **Client** — використовує Facade для спрощеного доступу до функціоналу всієї підсистеми.

## Переваги

- Ізолює клієнтів від компонентів складної підсистеми

## Недоліки

- Фасад ризикує стати "божественим" об’єктом, прив’язаним до всіх класів програми

  
```mermaid
classDiagram

    class Client {
        +OperationA()
        +OperationB()
    }

    class Facade {
        +OperationA()
        +OperationB()
    }

    class Subsystem1 {
        +Method1()
    }

    class Subsystem2 {
        +Method2()
    }

    Facade --> Subsystem1
    Facade --> Subsystem2
    Client --> Facade
```

```mermaid
sequenceDiagram
    participant Client
    participant Facade
    participant Class1
    participant Class2
    participant Class3

    Client->>Facade: request()

    Facade->>Class1: operation1()
    Facade->>Class2: operation2()
    Facade->>Class3: operation3()
```

# Патерн Visitor

## Опис

**Visitor** — це поведінковий патерн, який дозволяє додати нову операцію для цілої ієрархії класів, не змінюючи код цих класів.

## Структура

- **Visitor** — інтерфейс або абстрактний клас, що оголошує методи Visit() для кожного типу елементів.
- **ConcreteVisitor** — реалізує конкретні операції для кожного типу елементів.
- **Element** — інтерфейс або абстрактний клас для об’єктів, які приймають відвідувача (Accept(visitor)).
- **ConcreteElement** — реалізує Accept(visitor) і викликає відповідний метод у відвідувача.
- **Client** — 	ініціює відвідування об’єктів.

## Переваги

- Спрощує додавання операцій, працюючих зі складними структурами об’єктів
- Об’єднує споріднені операції в одному класі
- Відвідувач може накопичувати стан при обході структури елементів

## Недоліки

- Патерн невиправданий, якщо ієрархія елементів часто змінюється
- Може призвести до порушення інкапсуляції елементів

```mermaid
classDiagram
    class Client {
        +VisitConcreteElementA(a)
        +VisitConcreteElementB(b)
    }

    class Visitor {
        <<interface>>
        +VisitConcreteElementA(a)
        +VisitConcreteElementB(b)
    }

    class ConcreteVisitor {
        +VisitConcreteElementA(a)
        +VisitConcreteElementB(b)
    }

    class Element {
        <<interface>>
        +Accept(visitor)
    }

    class ConcreteElementA {
        +Accept(visitor)
        +OperationA()
    }

    class ConcreteElementB {
        +Accept(visitor)
        +OperationB()
    }

    Client --> Element
    Client --> ConcreteVisitor
    Visitor <|-- ConcreteVisitor
    Element <|-- ConcreteElementA
    Element <|-- ConcreteElementB
    ConcreteElementA --> Visitor : Accept()
    ConcreteElementB --> Visitor : Accept()
```

```mermaid
sequenceDiagram
    participant Client
    participant ConcreteVisitor
    participant ElementA
    participant ElementB

    Client->>ElementA: Accept(visitor)
    ElementA->>ConcreteVisitor: VisitConcreteElementA(this)

    Client->>ElementB: Accept(visitor)
    ElementB->>ConcreteVisitor: VisitConcreteElementB(this)
```

# Патерн Balking

## Опис

**Balking** — Патерн Balking використовується, коли об’єкт має певний стан, і операцію можна виконати лише якщо цей стан дозволяє це.

Якщо поточний стан невідповідний — операція ігнорується (або повертає одразу).

## Структура

- **Context (GuardedObject)** — об'єкт, над яким викликається операція.
- **Thread** — 	потік, який викликає метод.
- **Balking check** — перевірка стану перед виконанням.
- **Lock** — синхронізація, щоб уникнути race condition.

```mermaid
classDiagram
    class WashingMachine {
        -bool isRunning
        +Start()
        +Run()
    }

    class Thread {
        +Run()
    }

    Thread --> WashingMachine : calls Start()
```

```mermaid
sequenceDiagram
    participant Thread1
    participant WashingMachine

    Thread1->>WashingMachine: Start()
    alt isRunning == false
        WashingMachine->>WashingMachine: Run()
    else isRunning == true
        WashingMachine-->>Thread1: Ignore (balking)
    end
```
