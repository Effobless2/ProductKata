# Product KATA

## Architecure choisie
### ProductKata.Domain
Contient l'ensemble de notre logique m�tier, est agnostique de stockage des donn�es, 
de la date syst�me et du type d'application exploitante.'
#### ProductKata.Domain.Repository
Interfaces de contrat de stockage des donn�es

#### ProductKata.Domain.Models
Classes m�tier manipul�es

#### ProductKata.Domain.Service
Service dans laquelle est impl�ment�e la logique m�tier

#### ProductKata.Domain.Tools
Contient un helper pour les dates et permet de faciliter la mise en place de tests unitaires


### ProductKata.DB
Impl�mentation des repositories de ProductKata.Domain

### ProductKata.Api
Exploite ProductKata.Domain et g�re l'injection des d�pendancess

### ProductKata.UnitTests
Contient des tests unitaires sur la couche ProductKata.Domain