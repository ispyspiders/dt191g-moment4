# Moment 4 - API/REST-webbtjänst
#### DT191G – Webbutveckling med .NET
#### Av Kajsa Classon, VT25.

Ett API skapat med ASP.NET Core som hanterar en låtlista där data lagras i en SQLite-databas med två tabeller (låtar och kategorier). 

### Routes
| Metod         | Ändpunkt                     | Beskrivning   |
| ------------- | -------------------------    | ------------- |
| GET           | /api/Category                | Hämtar alla kategorier |
| GET           | /api/Category/{id}           | Hämtar en specifik kategori |
| PUT           | /api/Categor/{id}            | Uppdaterar en kategori [^1] |
| POST          | /api/Category                | Lägger till ny kategori [^2] |
| DELETE        | /api/Category/{id}           | Raderar kategori med valt id |
| GET           | /api/Song                    | Hämtar alla låtar |
| GET           | /api/Song/{id}               | Hämtar en specifik låt |
| PUT           | /api/Song/{id}               | Uppdaterar en låt [^3] |
| POST          | /api/Song                    | Lägger till ny kategori [^4] |
| DELETE        | /api/Song/{id}               | Raderar låt med valt id |

[^1] Kräver att ett kategori-objekt skickas med.
[^2] Kräver att ett kategori-objekt skickas med (ej id)

Ett kategori-objekt skickas som JSON med följande struktur:

``` 
{
    "Id": 1,
    "Name": "Pop",
}
```

[^3] Kräver att ett låt-objekt skickas med.
[^4] Kräver att ett låt-objekt skickas med (ej id)

``` 
{
    "Id": 1,
    "Artist": "Stray Kids",
    "Title": "God's menu",
    "Length": 168,
    "CategoryId": 3
}
```

### Uppgiftsbeskrivning
För godkänt genomförande av laboration ska ni i er applikation visa på följande:
* Att ni skapat ett API i ASP.net Core med CRUD.
* Att det går att lägga till, läsa ut, radera och uppdatera data i låtlistan via exempelvis Postman, Advanced REST-client eller liknande program. (Ni behöver ej skapa en applikation som konsumerar API'et).
* Data för låtlistan lagras i valfri databas-server (ej In Memory DB).

För att erhålla ett plus-poäng (1p) för denna laboration, ska lösningen även (förutom det ovan för godkänt) omfatta följande:
* API'et ska inte vara ett minimalt API, utan använda controller.
* Databasen i din lösning ska innehålla minst två stycken tabeller - Du väljer själv hur du vill struktrera ditt data, om du till exempel vill göra kategorier i egen tabell, göra olika skivor som tillhör en artist eller kanske göra kommentarer/recension till respektive album? .
* Returnerat data skall erbjuda god kvalitet och struktur. Undvik att returnera enbart id för data i relationer, utan försök att returnera hela objektet.

Vidare krävs för att VG ska erhållas på laborationen att din framställning och praktiska lösning håller god kvalitet, bra struktur och på ett sunt sätt förhåller sig till för kursen relevant material.