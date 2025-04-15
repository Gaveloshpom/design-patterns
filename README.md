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
