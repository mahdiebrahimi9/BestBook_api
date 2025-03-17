using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId
{
    public record GetCategoryByParentIdQuery(long parentId) : IQuery<List<ChildeCategoryDto>>;
    public class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<ChildeCategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryByParentIdQueryHandler(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<ChildeCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Categories.Where(f => f.ParentId == request.parentId)
                .ToListAsync(cancellationToken);
            return result.MapChildren();
        }
    }
}
