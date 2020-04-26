﻿using CollAction.Data;
using CollAction.Helpers;
using CollAction.Models;
using CollAction.Services.Projects;
using GraphQL.Authorization;
using GraphQL.EntityFramework;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CollAction.GraphQl.Queries
{
    public sealed class ProjectGraph : EfObjectGraphType<ApplicationDbContext, Project>
    {
        public ProjectGraph(IEfGraphQLService<ApplicationDbContext> entityFrameworkGraphQlService) : base(entityFrameworkGraphQlService)
        {
            Field<NonNullGraphType<IdGraphType>>(nameof(Project.Id), resolve: x => x.Source.Id);
            Field(x => x.AnonymousUserParticipants);
            Field(x => x.BannerImageFileId, true);
            Field(x => x.CreatorComments, true);
            Field(x => x.Description);
            Field(x => x.DescriptionVideoLink, true);
            Field(x => x.DescriptiveImageFileId, true);
            Field(x => x.CardImageFileId, true);
            Field(x => x.DisplayPriority);
            Field(x => x.End);
            Field(x => x.Goal);
            Field(x => x.IsActive);
            Field(x => x.IsClosed);
            Field(x => x.IsComingSoon);
            Field(x => x.Name);
            Field(x => x.NumberProjectEmailsSent);
            Field<IdGraphType>(nameof(Project.OwnerId), resolve: x => x.Source.OwnerId);
            Field(x => x.Proposal);
            Field(x => x.RemainingTime);
            Field(x => x.Start);
            Field(x => x.Status);
            Field(x => x.Target);
            Field(x => x.NameNormalized);
            Field<NonNullGraphType<StringGraphType>>(nameof(Project.Url), resolve: p => p.Source.Url.ToString());
            Field<NonNullGraphType<BooleanGraphType>>(
                "canSendProjectEmail",
                resolve: c =>
                {
                    return c.GetUserContext().ServiceProvider.GetRequiredService<IProjectService>().CanSendProjectEmail(c.Source);
                });
            FieldAsync<NonNullGraphType<StringGraphType>>(
                nameof(Project.RemainingTimeUserFriendly),
                resolve: async c =>
                {
                    if (c.Source.ParticipantCounts == null)
                    {
                        c.Source.ParticipantCounts = await c.GetUserContext().Context.ProjectParticipantCounts.FindAsync(c.Source.Id);
                    }

                    return c.Source.RemainingTimeUserFriendly;   
                });
            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                nameof(Project.IsSuccessfull),
                resolve: async c =>
                {
                    if (c.Source.ParticipantCounts == null)
                    {
                        c.Source.ParticipantCounts = await c.GetUserContext().Context.ProjectParticipantCounts.FindAsync(c.Source.Id);
                    }

                    return c.Source.IsSuccessfull;   
                });
            FieldAsync<NonNullGraphType<BooleanGraphType>>(
                nameof(Project.IsFailed),
                resolve: async c =>
                {
                    if (c.Source.ParticipantCounts == null)
                    {
                        c.Source.ParticipantCounts = await c.GetUserContext().Context.ProjectParticipantCounts.FindAsync(c.Source.Id);
                    }

                    return c.Source.IsFailed;   
                });
            FieldAsync<NonNullGraphType<IntGraphType>>(
                nameof(Project.TotalParticipants),
                resolve: async c =>
                {
                    if (c.Source.ParticipantCounts == null)
                    {
                        c.Source.ParticipantCounts = await c.GetUserContext().Context.ProjectParticipantCounts.FindAsync(c.Source.Id);
                    }

                    return c.Source.TotalParticipants;
                });
            FieldAsync<NonNullGraphType<IntGraphType>>(
                nameof(Project.Percentage),
                resolve: async c =>
                {
                    if (c.Source.ParticipantCounts == null)
                    {
                        c.Source.ParticipantCounts = await c.GetUserContext().Context.ProjectParticipantCounts.FindAsync(c.Source.Id);
                    }

                    return c.Source.Percentage;
                });
            AddNavigationField(nameof(Project.DescriptiveImage), c => c.Source.DescriptiveImage);
            AddNavigationField(nameof(Project.BannerImage), c => c.Source.BannerImage);
            AddNavigationField(nameof(Project.CardImage), c => c.Source.CardImage);
            AddNavigationField(nameof(Project.ParticipantCounts), c => c.Source.ParticipantCounts);
            AddNavigationField(nameof(Project.Owner), c => c.Source.Owner, typeof(RestrictedApplicationUserGraph));
            AddNavigationListField(nameof(Project.Categories), c => c.Source.Categories);
            AddNavigationListField(nameof(Project.Participants), c => c.Source.Participants).AuthorizeWith(AuthorizationConstants.GraphQlAdminPolicy);
            AddNavigationListField(nameof(Project.Tags), c => c.Source.Tags);
        }
    }
}
