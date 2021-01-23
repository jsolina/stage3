"#stage3 details" 

"stage3-api" this folder is for backend side(api)

"stage3-wpf" this folder is for client side

"stage3-db.sql" for mysql database.

*Frontend - WPF (xaml)*
    - Patterns:
        1.MVVM
        2.Repository Pattern

    - Dependencies:
        1. RestSharp
        2. MatterialDesign UI/Theme
        4. Microsoft Entity Framework Core (EFCore)

*Backend - ASP.NET Core Web API (C#)*
    - Patterns:
        1.MVC
        2.Repository Pattern
    
    - Dependencies:
        1. Serilog
        2. Masking.Serilog
        3. Seq
        4. Microsoft Entity Framework Core (EFCore)
        5. Swashbuckle(Swagger)

*Database: MYSql Server 8.0*
        Database name: todo

        tables:
            1. itemlist
            2. tasklist

