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
