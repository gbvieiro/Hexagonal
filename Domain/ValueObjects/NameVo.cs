using Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class NameVo
{
    public NameVo() { }

    public NameVo(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;

        Validate();
    }

    [Key]
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }

    private void Validate()
    {
        if (!IsValid())
        {
            throw new InvalidNameException("Invalid Name");
        }
    }
}