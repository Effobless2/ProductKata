![Screenshot 2021-05-26 201036](https://user-images.githubusercontent.com/33808798/119710772-0df0fd80-be5f-11eb-8f0c-7c6a7a515c6b.png)
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
Pour le moment, ne stocke le data que dans des variables statiques mais il suffira
de réimplémenter ces dernières avec une connexion aux bases de données et de reconfigurer
l'injection de dépendance au niveau du startup.

### ProductKata.Api
Exploite ProductKata.Domain et gère l'injection des dépendances

### ProductKata.UnitTests
Contient des tests unitaires sur la couche ProductKata.Domain


## Comment lancer ?
- Ouvrir le fichier .sln avec Visual Studio
- Lancer IIS Express

