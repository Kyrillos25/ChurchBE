﻿using ChurchBE.Common.Application.Messaging;

namespace ChurchBE.Modules.Users.Application.Users.RegisterUser;
public sealed record RegisterUserCommand(string Email, string Password, string FirstName, string LastName, string Mobile)
    : ICommand<Guid>;

