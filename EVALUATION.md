## Hace todos los puntos pedidos (40%)

#### El nombre del repositorio es el correcto (mdas-web-${nombre}_${apellido})

OK

#### Permite obtener los detalles de un pokemon vía endpoint (datos + número de veces que se ha marcado como favorito)

OK

#### Actualiza el contador de favoritos vía eventos

OK

#### ¿Se controlan las excepciones de dominio? Y si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP?

OK

#### Tests unitarios

OK

#### Tests de aceptación

- OK, aunque no se está testeando el flujo del subscriber.

#### Tests de integración

- No hay tests de integración del in memory.

**Puntuación: 33/40**

## Se aplican conceptos explicados (50%)

#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)

OK

#### Aggregates + VOs

OK

#### No se trabajan con tipos primitivos en dominio

OK

#### Hay servicios de dominio

- Tendría más sentido tener un servicio de dominio llamado `PokemonIncreaser` que un `PokemonCreator` y delegar
  aquí la responsabilidad de obtener el pokemon, aumentar el número de pokemon favoritos y de guardar en el repositorio.
- El servicio de dominio, tras obtener el pokemon e incrementar el número de veces que se ha marcado como favorito, el
  siguiente paso, debería ser guardarlo en el repositorio. La función create (named constructor) su responsabilidad es
  crear Pokemons desde 0:

```
  var pokemon = _pokemonRepository.Find(pokemonId);
  pokemon.IncreasePokemonFavouriteNumberOfTimes();
    _pokemonRepository.Save(pokemon);
```

#### Hay use cases en aplicación reutilizables

- OK, aunque tendría más sentido que el caso de uso indicara que acción realiza: en vez de `PokemonAddAsFavoriteUseCase`
  sería mejor `PokemonFavoriteIncreaserUseCase` o algo similar.

#### Se aplica el patrón repositorio

OK

#### Se usan subscribers

- OK, aunque el nombre `NotifyPokemonOnUserPokemonFavoriteCreatedSubscriber` es un poco raro, ya que su funcionalidad no
  es notificar sino incrementar.

#### Se lanzan eventos de dominio

OK

#### Se utilizan object mothers

OK

**Puntuación: 37/50**

## Facilidad setup + README (10%)

#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo usar la aplicación"

OK

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"

OK

**Puntuación: 10/10**

## Extras

- Commits en "baby steps". Pequeños y legibles

**Puntuación: +3**

**PUNTUACIÓN FINAL: 83/100**
