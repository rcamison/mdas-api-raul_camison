# Project ePokemon | Raúl Camison

This project was evolved by **Raúl Camisón** for the course Software Design 2 with the programming language: **C#**

---

### Bounded Context (Challenge #1): 

* **Pokemon**

### Module: 

* Type

### Entities:

* Type

### Value Objects:

* TypeName
* PokemonName

### Exceptions:

* PokemonNotFoundException
* TypeRepositoryIsNotRespondingException

---

### Bounded Context (Challenge #2): 

* **Users**

### Module: 

* User

### Entities:

* User
* PokemonFavorite
* PokemonFavoritesCollection

### Value Objects:

* PokemonId
* UserId
* UserName

### Exceptions:

* PokemonFavoriteAlreadyExistException
* UserDoesNotExistException
* UserAlreadyExistsException

---

### Bounded Context (Challenge #3): 

* **Pokemon**

### Module: 

* Pokemon

### Entities:

* Pokemon

### Value Objects:

* PokemonId
* PokemonName
* PokemonHeight
* PokemonWeight
* PokemonFavouriteNumberOfTimes

### Exceptions:

* PokemonNotFoundException
* PokemonRepositoryIsNotRespondingException

---

### Bounded Context (Challenge #Individual): 

* **Users**

### Module: 

* User

### Events:

* PokemonFavoriteCreatedEvent

---

### RabbitMQ

### Credentials: 

* URL: http://localhost:15672
* User: raulcamison
* Password: camisonraul

### Configuration: 

* Exchange: UserExchange
* Queue: UserPokemonFavorites

---

### Requeriments to Run App:

- Docker
- Docker Compose
- Postman
- Chrome
  
---

### Run App Steps:

Further instructions in each challenge:

* #### [Challenge #1](Challenge1.md)
* #### [Challenge #2](Challenge2.md)
* #### [Challenge #3](Challenge3.md)
* #### [Challenge #Individual](ChallengeIndividual.md)

---

## Authors Project

| **Raúl Camisón García**  | <img src="https://estudy.salle.url.edu/fotos2/eac/raul.camison.jpg" alt="drawing" width="35"/>  |
| :-----------                        | ----------- |