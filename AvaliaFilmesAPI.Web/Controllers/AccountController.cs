
using AvaliaFilmesAPI.Domain;
using AvaliaFilmesAPI.Web.ViewModel.AvaliaFilmesAPI.Web.ViewModels;
using AvaliaFilmesAPI.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterViewModels model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return Ok(new { Message = "Usuário registrado com sucesso!" });
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginViewModels model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: true, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Ok(new { Message = "Login bem-sucedido!" });
        }

        return Unauthorized(new { Message = "Usuário ou senha inválidos." });
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { Message = "Logout bem-sucedido." });
    }

    [HttpGet("status")]
    public async Task<IActionResult> Status()
    {
        if (User?.Identity?.IsAuthenticated == true)
        {
            var user = await _userManager.GetUserAsync(User);

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new
            {
                authenticated = true,
                id = user.Id,
                username = user.UserName,
                email = user.Email,
                roles
            });

        }

        return Ok(new { authenticated = false });
    }


    [HttpPut("update-account")]
    [Authorize] 
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized("Usuário não encontrado.");
        }

        bool profileChanged = false;
        IdentityResult profileUpdateResult = IdentityResult.Success;

        if (user.UserName != model.Username || user.Email != model.Email)
        {
            user.UserName = model.Username;
            user.Email = model.Email;
            profileUpdateResult = await _userManager.UpdateAsync(user);
            profileChanged = true;
        }

        bool passwordChanged = false;
        IdentityResult passwordUpdateResult = IdentityResult.Success;

        if (!string.IsNullOrEmpty(model.NewPassword))
        {
            passwordChanged = true;
            passwordUpdateResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }

        if (profileUpdateResult.Succeeded && passwordUpdateResult.Succeeded)
        {
            if (!profileChanged && !passwordChanged)
            {
                return Ok(new { Message = "Nenhuma alteração foi fornecida." });
            }
            return Ok(new { Message = "Conta atualizada com sucesso!" });
        }
        else
        {
            var errors = profileUpdateResult.Errors.Concat(passwordUpdateResult.Errors);
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }
    }



}