using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourOfHeroesApi.Domain;

namespace TourOfHeroesApi;

public static class HeroRoutes
{
    public static RouteGroupBuilder MapHeroRoutes(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetHeroes);
        group.MapPost("/", AddHero);
        return group;
        
    }

    public static async Task<Ok<List<HeroEntity>>> GetHeroes(HeroDataContext context)
    {
        var response = await context.Heroes.ToListAsync();
        return TypedResults.Ok(response);
    }

    public static async Task<Created<HeroEntity>> AddHero([FromBody]HeroCreateRequest request, HeroDataContext context)
    {
        var entity = new HeroEntity { Name = request.Name };
        context.Heroes.Add(entity);
        await context.SaveChangesAsync();
        return TypedResults.Created($"{entity.Id}", entity);
    }

}

public record HeroCreateRequest(string Name);