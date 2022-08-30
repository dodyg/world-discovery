# world-discovery

This is a travelling/living place database. The idea is to allow incremental and granular enrichment of information regarding a place from multiple facet.

For example, we can start covering a city by its restaurants. Then we can group these restaurants by their neighbourhoods. Then we can attach more information regarding other places in the neighbourhoods that are notable. 

We will be using the graph ability of [SurrealDB](https://github.com/surrealdb/surrealdb) to achieve this.

The UI will rely on Blazor Web Assembly running on .NET 7 preview. 