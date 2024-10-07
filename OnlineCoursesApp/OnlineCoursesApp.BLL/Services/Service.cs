using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;

public class Service<T> : IService<T> where T : class
{
    private readonly OnlineCoursesContext _context;
    private readonly DbSet<T> _dbSet;

    public Service(OnlineCoursesContext context)
    {
        _context = context;
        _dbSet = context.Set<T>(); 
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable(); 
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity); 
        _context.SaveChanges(); 
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges(); 
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _dbSet.Remove(entity); 
            _context.SaveChanges(); 
        }
    }
}
