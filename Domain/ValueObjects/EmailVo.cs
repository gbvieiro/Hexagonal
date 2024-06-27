using Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class EmailVo
{
    public EmailVo() { }

    public EmailVo(Guid id, string address)
    {
        Id = id;
        Address = address;

        Validate();
    }

    [Key]
    public Guid Id { get; private set; }

    public string Address { get; private set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Address) && Address.Contains("@");
    }

    private void Validate()
    {
        if (!IsValid())
        {
            throw new InvalidEmailException("Invalid Email");
        }
    }
}
