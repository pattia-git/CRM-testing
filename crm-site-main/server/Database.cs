﻿using server.Enums;

namespace server;

using Npgsql;

public class Database
{

    private readonly string _host = "217.76.56.135";
    private readonly string _port = "5432";
    private readonly string _username = "postgres";
    private readonly string _password = "FlickeringCustomerMoves29";
    private readonly string _database = "crmdb";

    private NpgsqlDataSource _connection;

    
    public NpgsqlDataSource Connection()
    {
        return _connection;
    }

    public Database()
    {
        string connectionString = $"Host={_host};Port={_port};Username={_username};Password={_password};Database={_database}";
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.MapEnum<Role>("role");
        dataSourceBuilder.MapEnum<IssueState>("issue_state");
        dataSourceBuilder.MapEnum<Sender>("sender");
        _connection = dataSourceBuilder.Build();
    }
}