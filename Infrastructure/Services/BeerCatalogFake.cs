using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Services.Interfaces;
using Infrastructure.Entities;

namespace Infrastructure.Services
{
    public class BeerCatalogFake : IBeerCatalog
    {
        private readonly List<Beer> Beers = new List<Beer>();

        public BeerCatalogFake()
        {
            for (var i = 0; i < 10000; i++)
            {
                var rnd = new Random();
                
                Beers.Add(new Beer
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    Label = "Label " + i,
                    Description = "Description " + i,
                    Stock = rnd.Next(100)
                });
            }
        }
        
        public IQueryable<BeerModel> GetAllBeers()
        {
            return Beers
                .AsQueryable()
                .Select(b => new BeerModel(
                    b.Id,
                    b.CreatedAt,
                    b.LastUpdate,
                    b.Label,
                    b.Description,
                    b.Stock
                ));
        }

        public BeerModel GetOneBeer(Guid id)
        {
            var beer = Beers.FirstOrDefault(b => b.Id.Equals(id));

            return beer == null
                ? null
                : new BeerModel(
                    beer.Id,
                    beer.CreatedAt,
                    beer.LastUpdate,
                    beer.Label,
                    beer.Description,
                    beer.Stock
                );
        }

        public BeerModel AddBeer(BeerModel beer)
        {
            var entity = new Beer
            {
                Id = beer.Id.Value,
                CreatedAt = beer.CreatedAt.Value,
                LastUpdate = beer.LastUpdate.Value,
                Label = beer.Label.Value,
                Description = beer.Description.Value,
                Stock = beer.Stock.Value
            };

            Beers.Add(entity);

            return beer;
        }

        public BeerModel UpdateBeer(BeerModel beer)
        {
            var entity = Beers.FirstOrDefault(b => b.Id.Equals(beer.Id.Value));

            if (entity == null) return null;

            var newEntity = new Beer
            {
                Id = beer.Id.Value,
                CreatedAt = beer.CreatedAt.Value,
                LastUpdate = beer.LastUpdate.Value,
                Label = beer.Label.Value,
                Description = beer.Description.Value,
                Stock = beer.Stock.Value
            };

            Beers.Remove(entity);
            Beers.Add(newEntity);

            return new BeerModel(
                newEntity.Id,
                newEntity.CreatedAt,
                newEntity.LastUpdate,
                newEntity.Label,
                newEntity.Description,
                newEntity.Stock
            );
        }

        public void DeleteBeer(Guid id)
        {
            Beers.Remove(Beers.FirstOrDefault(b => b.Id.Equals(id)));
        }
    }
}