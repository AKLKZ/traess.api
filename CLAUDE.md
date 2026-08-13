# TraessApi

## Convenciones obligatorias

- Todo método público que represente una operación de negocio (servicios, repositorios,
  handlers, endpoints) DEBE devolver `Traess.Domain.Common.Result` (si no retorna dato)
  o `Traess.Domain.Common.Result<T>` (si retorna una entidad/DTO), en vez de lanzar
  excepciones para flujo de control o devolver el tipo "desnudo".
- Al propagar un fallo desde una capa inferior hacia una superior, usar
  `PropagateFail()` / `PropagateFail<TNew>()` en vez de reconstruir `Errors` a mano.
- Los errores se modelan con `Traess.Domain.Common.Error` (forma compatible con
  `ProblemDetails`); `Traess.Api` los convierte a `ProblemDetails` reales mediante
  AutoMapper (`Traess.Api.Common.MappingProfile`, inyectando `IMapper`) antes de
  devolverlos en las respuestas HTTP.

## Idioma del código

- Los nombres de clases, propiedades, métodos, namespaces, variables y los comentarios
  internos del código SIEMPRE se escriben en inglés, aunque el dominio de negocio o la
  conversación con el usuario se exprese en castellano.
