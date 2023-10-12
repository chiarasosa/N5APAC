Para registrar la dependencia se uso el metodo 
builder.Services.AddScoped<IStudentsRepository<Student>, StudentsRepository<Student>>();
incluido en la clase Program. 
Se hizo mediante el metodo AddScoped para que se cree una unica instancia de StudentRepository por cada solicitud HTTP,
para que cada solicitud tenga su propia instancia independiente.
De haber utilizado AddTransient se crearia una instancia cada vez que se solicita la dependencia (no es conveniente para
mantener el estado de una base de datos en una aplicacion web) y de haberutilizado AddSingleton, una
unica instancia para toda la aplicacion (no es util cuando se requiere una nueva instancia para cada solicitud web).
