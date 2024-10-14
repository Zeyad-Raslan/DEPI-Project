<<<<<<< HEAD
﻿using System.Linq;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f

namespace OnlineCoursesApp.BLL.Services
{
    public interface IService<T> where T : class
    {
<<<<<<< HEAD
        // Retrieve all entities in a queryable format (for filtering, ordering, etc.)
        IQueryable<T> Query();

        // Retrieve a single entity by its ID
        T GetById(int id);

        // Add a new entity
        void Add(T entity);

        // Update an existing entity
        void Update(T entity);

        // Delete an entity by its ID
        void Delete(int id);

        // Optional: Save changes to persist data to the database
        void SaveChanges();
    }
}
=======
        IQueryable<T> Query();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}


>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
