using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities;

public sealed class User
{
    public Guid Id { get; private set; }
    public NameVo? Name { get; private set; }
    public EmailVo? Email { get; private set; }

    public User() { }

    public User(Guid id, NameVo name, EmailVo email)
    {
        Id = id;

        Validate(name, email);

        Name = name;
        Email = email;
    }

    public void Update(NameVo name, EmailVo email)
    {
        Validate(name, email);

        Name = name;
        Email = email;
    }

    private static void Validate(NameVo name, EmailVo email)
    {
        if (name is null || (!name.IsValid()))
        {
            throw new InvalidNameException("Invalid Name");
        }

        if (email is null || !email.IsValid())
        {
            throw new InvalidEmailException("Invalid Email");
        }
    }
}