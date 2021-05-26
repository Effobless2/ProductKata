# Product KATA

## Architecure choisie
### ProductKata.Domain
Contient l'ensemble de notre logique métier, est agnostique de stockage des données, 
de la date système et du type d'application exploitante.'
#### ProductKata.Domain.Repository
Interfaces de contrat de stockage des données

#### ProductKata.Domain.Models
Classes métier manipulées

#### ProductKata.Domain.Service
Service dans laquelle est implémentée la logique métier

#### ProductKata.Domain.Tools
Contient un helper pour les dates et permet de faciliter la mise en place de tests unitaires


### ProductKata.DB
Implémentation des repositories de ProductKata.Domain

### ProductKata.Api
Exploite ProductKata.Domain et gère l'injection des dépendancess

### ProductKata.UnitTests
Contient des tests unitaires sur la couche ProductKata.Domain