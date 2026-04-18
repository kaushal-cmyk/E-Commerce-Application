# E-Commerce Application

### This project is made to explore different Dotnet architecture 
1. Clean Architecture / Domain Driven Design
2. Repository Pattern

#### Audited Entries 
1. Entity<TKey> => just id 
2. AuditedEntity<TKey> => Id + Created 
3. FullAuditedEntity<TKey> => Id + Created + Updated + IsDeleted
4. AggregateRoot<TKey> => Id + Aggregate benavior 
5. AuditedAggegrateRoot<Tkey> => Id + Created + Aggragate behavior 
6. FullAuditedAggregateRoot<Tkey> => Id + everything + Aggregate behavior
7. EnableSoftDelete => IsDeleted 
8. HasAdditionalMetaData => AdditionalDetails + Tags
9. ValueObjects => marks as value objects 


### ---Er-Diagram--- ###

![Flow](Docs/er-diagram.gif)
