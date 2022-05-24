using System;
using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;


namespace TreinamentoTestes;

public class Tests
{
    public RestRequest request;
    private static IRestClient _client;

    [OneTimeSetUp]
    public static void InicializeRestCliemt() =>
        _client = new RestClient("https://api.trello.com");

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void CheckGetBoards()
    {
        request = new RestRequest("/1/members/{member}/boards");
        request.AddQueryParameter("key", "5413388a87e76f00b0575c088ce0792d")
            .AddQueryParameter("token", "d5903d6e31ea34e0f9756a04aa4166f61be03985a59a147ab35a3a4ed14caa0b")
            .AddUrlSegment("member", "flavioldias"); // Adiciona variavel no PathParam

        var response = _client.Get(request);
        Console.WriteLine(response.Content);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
    [Test]
    public void CheckGetBoard()
    {
        request = new RestRequest("/1/boards/{id}");
        request.AddQueryParameter("key", "5413388a87e76f00b0575c088ce0792d")
            .AddQueryParameter("token", "d5903d6e31ea34e0f9756a04aa4166f61be03985a59a147ab35a3a4ed14caa0b")
            .AddUrlSegment("id", "6279792807ac588844ca03df"); // Adiciona variavel no PathParam

        var response = _client.Get(request);
        Console.WriteLine(response.Content);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("Melhorias Exact Sales", JToken.Parse(response.Content).SelectToken("name").ToString()); // Extrai o retorno do Json, a chave name
    }
}