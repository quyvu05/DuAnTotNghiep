﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Infrastructure.Data;
using Shop.Module.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Module.Core.Controllers;

/// <summary>
/// Widget instance API controller, providing interface operations related to widget instances
/// </summary>
[Authorize(Roles = "admin")]
[Route("api/widget-instances")]
public class WidgetInstanceApiController : ControllerBase
{
    private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
    private readonly IRepository<Widget> _widgetRespository;

    public WidgetInstanceApiController(
        IRepository<WidgetInstance> widgetInstanceRepository,
        IRepository<Widget> widgetRespository)
    {
        _widgetInstanceRepository = widgetInstanceRepository;
        _widgetRespository = widgetRespository;
    }

    /// <summary>
    /// Retrieve all widget instances
    /// </summary>
    /// <returns>All widget instances information </returns>
    [HttpGet]
    public async Task<Result> Get()
    {
        var widgetInstances = await _widgetInstanceRepository.Query()
            .Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                WidgetType = x.Widget.Name,
                x.WidgetZoneId,
                x.WidgetId,
                WidgetZone = x.WidgetZone.Name,
                CreatedOn = x.CreatedOn,
                EditUrl = x.Widget.EditUrl,
                PublishStart = x.PublishStart,
                PublishEnd = x.PublishEnd,
                DisplayOrder = x.DisplayOrder
            }).ToListAsync();

        return Result.Ok(widgetInstances.OrderBy(c => c.WidgetZoneId).ThenBy(c => c.DisplayOrder));
    }

    /// <summary>
    /// Delete widget instance based on widget instance ID
    /// </summary>
    /// <param name="id">widget instance ID </param>
    /// <returns>Operation result </returns>
    [HttpDelete("{id:int:min(1)}")]
    public async Task<Result> Delete(int id)
    {
        var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
        if (widgetInstance != null)
        {
            widgetInstance.IsDeleted = true;
            widgetInstance.UpdatedOn = DateTime.Now;
            _widgetInstanceRepository.SaveChanges();
        }

        return Result.Ok();
    }

    /// <summary>
    /// Retrieve the number of widget instances
    /// </summary>
    /// <returns>Number of widget instances </returns>
    [HttpGet("number-of-widgets")]
    public async Task<Result> GetNumberOfWidgets()
    {
        var total = await _widgetInstanceRepository.Query().CountAsync();
        return Result.Ok(total);
    }
}
