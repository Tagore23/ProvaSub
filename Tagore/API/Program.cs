using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
    )
);

var app = builder.Build();

app.MapGet("/", () => "Prova A1");

// GET: http://localhost:5250/aluno/listar
app.MapGet("/aluno/listar", ([FromServices] AppDataContext ctx) =>
{
    var alunos = ctx.Alunos.ToList();
    if (alunos.Any())
    {
        return Results.Ok(alunos);
    }
    return Results.NotFound("Nenhum aluno encontrado");
});

// POST: http://localhost:5250/aluno/cadastrar
app.MapPost("/aluno/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Aluno aluno) =>
{
  
    if (string.IsNullOrEmpty(aluno.Nome) || string.IsNullOrEmpty(aluno.Sobrenome) || aluno.Altura <= 0 || aluno.Peso <= 0)
    {
        return Results.BadRequest("Todos os campos (Nome, Sobrenome, Altura e Peso) devem ser preenchidos corretamente.");
    }

 
    if (ctx.Alunos.Any(a => a.Nome == aluno.Nome && a.Sobrenome == aluno.Sobrenome))
    {
        return Results.BadRequest("Aluno com mesmo nome e sobrenome já existe!");
    }

 
    aluno.AlunoId = Guid.NewGuid().ToString();
    
 
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    

    return Results.Created($"/aluno/{aluno.AlunoId}", aluno);
});


// POST: http://localhost:5250/imc/cadastrar
app.MapPost("/imc/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] IMC request) =>
{
    var aluno = ctx.Alunos.Find(request.AlunoId);
    if (aluno == null)
    {
        return Results.NotFound("Aluno não encontrado");
    }

    var imc = new IMC
    {
        AlunoId = request.AlunoId,
        Peso = request.Peso,
        Altura = request.Altura,
        ValorIMC = request.Peso / (request.Altura * request.Altura),
        Classificacao = request.Peso / (request.Altura * request.Altura) < 18.5m ? "Magreza" :
                        request.Peso / (request.Altura * request.Altura) < 25m ? "Normal" :
                        request.Peso / (request.Altura * request.Altura) < 30m ? "Sobrepeso" : "Obesidade",
        DataCriacao = DateTime.UtcNow
    };

    ctx.IMCs.Add(imc);
    ctx.SaveChanges();
    return Results.Created($"/imc/{imc.Id}", imc);
});

// GET: http://localhost:5250/imc/listar
app.MapGet("/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    var imcs = ctx.IMCs
        .Select(i => new
        {
            i.Id,
            AlunoId = i.AlunoId,
            i.Peso,
            i.Altura,
            i.ValorIMC,
            i.Classificacao,
            i.DataCriacao
        })
        .ToList();

    return Results.Ok(imcs);
});

// PUT: http://localhost:5250/imc/atualizar/{id}
app.MapPut("/imc/atualizar/{id}", ([FromServices] AppDataContext ctx, int id, [FromBody] IMC request) =>
{
    var imc = ctx.IMCs.Find(id);
    if (imc == null)
    {
        return Results.NotFound("IMC não encontrado");
    }

    imc.Peso = request.Peso;
    imc.Altura = request.Altura;
    imc.ValorIMC = request.Peso / (request.Altura * request.Altura);

    // Classificar o IMC usando if/else
    imc.Classificacao = imc.ValorIMC < 18.5m ? "Magreza" :
                        imc.ValorIMC < 25m ? "Normal" :
                        imc.ValorIMC < 30m ? "Sobrepeso" : "Obesidade";

    ctx.SaveChanges();
    return Results.Ok(imc);
});

// GET: http://localhost:5250/aluno/{alunoId}/imc/listar
app.MapGet("/aluno/{alunoId}/imc/listar", ([FromServices] AppDataContext ctx, string alunoId) =>
{
    var imcs = ctx.IMCs
       .Where(i => i.AlunoId == alunoId)
       .Select(i => new
       {
           i.Id,
           i.Peso,
           i.Altura,
           i.ValorIMC,
           i.Classificacao,
           i.DataCriacao
       })
       .ToList();

    return Results.Ok(imcs);
});

// GET: http://localhost:5250/aluno/{alunoId}/imc/editar/{imcId}
app.MapGet("/aluno/{alunoId}/imc/editar/{imcId}", ([FromServices] AppDataContext ctx, string alunoId, int imcId) =>
{
    var imc = ctx.IMCs.Find(imcId);
    if (imc == null)
    {
        return Results.NotFound("IMC não encontrado");
    }

    return Results.Ok(new
    {
        imc.Id,
        imc.Peso,
        imc.Altura,
        imc.ValorIMC,
        imc.Classificacao,
        imc.DataCriacao
    });
});

// PUT: http://localhost:5250/aluno/{alunoId}/imc/atualizar/{imcId}
app.MapPut("/aluno/{alunoId}/imc/atualizar/{imcId}", ([FromServices] AppDataContext ctx, string alunoId, int imcId, [FromBody] IMC request) =>
{
    var aluno = ctx.Alunos.Find(alunoId);
    if (aluno == null)
        return Results.NotFound("Aluno não encontrado");

    var imc = ctx.IMCs.Find(imcId);
    if (imc == null)
        return Results.NotFound("IMC não encontrado");

    imc.Peso = request.Peso;
    imc.Altura = request.Altura;
    imc.ValorIMC = request.Peso / (request.Altura * request.Altura);

    if (imc.ValorIMC < 18.5m)
    {
        imc.Classificacao = "Magreza";
    }
    else if (imc.ValorIMC < 25m)
    {
        imc.Classificacao = "Normal";
    }
    else if (imc.ValorIMC < 30m)
    {
        imc.Classificacao = "Sobrepeso";
    }
    else
    {
        imc.Classificacao = "Obesidade";
    }

    ctx.SaveChanges();
    return Results.Ok(imc);
});
app.UseCors("Acesso Total");
app.Run();
