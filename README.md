Hexagonal Architecture
Hexagonal Architecture, also known as Ports and Adapters architecture, is a software architecture pattern aimed at creating highly flexible and decoupled systems, facilitating code maintenance, testability, and evolution.

Characteristics of Hexagonal Architecture
Ports (Ports): Ports are interfaces that define how the system communicates with the external world, including interactions with users, other systems, and external resources. These ports represent the system's inputs and outputs.

Adapters (Adapters): Adapters are components that implement the interfaces defined in the ports. They translate requests and responses between the internal system and the external world. Adapters can include user interfaces (UI), database adapters, API adapters, etc.

Core (Core): The core is where the business logic of the system resides. It is not directly tied to ports or adapters and therefore can remain isolated and independent of specific technologies.