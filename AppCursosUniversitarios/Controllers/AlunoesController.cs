
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppCursosUniversitarios.Models;

public class AlunoesController : Controller
{
    private readonly dbCursosUniversitariosContext _context;

    public AlunoesController(dbCursosUniversitariosContext context)
    {
        _context = context;
    }

    // GET: ALUNOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Alunos.ToListAsync());
    }

    // GET: ALUNOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aluno = await _context.Alunos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (aluno == null)
        {
            return NotFound();
        }

        return View(aluno);
    }

    // GET: ALUNOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ALUNOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NomeCompleto,Cpf,Email,Telefone,EscolhaCursos")] Aluno aluno)
    {
        if (ModelState.IsValid)
        {
            _context.Add(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(aluno);
    }

    // GET: ALUNOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound();
        }
        return View(aluno);
    }

    // POST: ALUNOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,NomeCompleto,Cpf,Email,Telefone,EscolhaCursos")] Aluno aluno)
    {
        if (id != aluno.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(aluno.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(aluno);
    }

    // GET: ALUNOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var aluno = await _context.Alunos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (aluno == null)
        {
            return NotFound();
        }

        return View(aluno);
    }

    // POST: ALUNOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno != null)
        {
            _context.Alunos.Remove(aluno);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AlunoExists(int? id)
    {
        return _context.Alunos.Any(e => e.Id == id);
    }
}
