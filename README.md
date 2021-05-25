## Bienvenu sur ma page GitHub

Dans le cadre du test technique, j'ai mis en place une solution avec :
- une architecture ntiers
- .Net 5
- EF Core 5
- Migration 

### Contenu du test
```
Développer une web API permettant de gérer un catalogue de produits (on se limitera à l'ajout d'un produit et à la récupération de tous les produits)
Un produit étant défini par:
- un nom
- un code (unique)
- une date de début de validité
- une date de fin de validité
La date de début doit être antérieure à la date de fin de validité.
Le code ainsi que l'architecture devra être "production ready" (ça n'est pas un POC).
La base pour stocker les produits sera une base SQL Server 2016 et l'application en .NET 5.0
```

### Avant de lancer

Merci de modifier la chaine de connexion "StockDB" dans le fichier appsettings.json avant de lancer le debug (La base de données sera créée automatiquement)

```markdown
{
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "StockDB": "Server=.\\SQLEXPRESS;Database=StockDB;Integrated Security=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
