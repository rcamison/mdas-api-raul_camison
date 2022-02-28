﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Users.User.Application;

namespace Users.User.Infrastructure
{

    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddTransient<CreateUserUseCase>();
            services.AddTransient<AddPokemonFavoriteUseCase>();
            services.AddMediatR(typeof(AddPokemonFavoriteUseCase).Assembly);
            return services;
        }
    }

}