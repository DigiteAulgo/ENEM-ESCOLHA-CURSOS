
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppCursosUniversitarios.Models;

public class EscolhaCursoesController : Controller
{
    private readonly dbCursosUniversitariosContext _context;

    public EscolhaCursoesController(dbCursosUniversitariosContext context)
    {
        _context = context;
    }

    // GET: ESCOLHACURSOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.EscolhaCursos.ToListAsync());
    }

    // GET: ESCOLHACURSOS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var escolhacurso = await _context.EscolhaCursos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (escolhacurso == null)
        {
            return NotFound();
        }

        return View(escolhacurso);
    }

    // GET: ESCOLHACURSOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ESCOLHACURSOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,AlunoId,CursoId,OrdemPreferencia,DataEscolha,Aluno,Curso")] EscolhaCurso escolhacurso)
    {
        if (ModelState.IsValid)
        {
            _context.Add(escolhacurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(escolhacurso);
    }

    // GET: ESCOLHACURSOS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var escolhacurso = await _context.EscolhaCursos.FindAsync(id);
        if (escolhacurso == null)
        {
            return NotFound();
        }
        return View(escolhacurso);
    }

    // POST: ESCOLHACURSOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,AlunoId,CursoId,OrdemPreferencia,DataEscolha,Aluno,Curso")] EscolhaCurso escolhacurso)
    {
        if (id != escolhacurso.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(escolhacurso);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscolhaCursoExists(escolhacurso.Id))
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
        return View(escolhacurso);
    }

    // GET: ESCOLHACURSOS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var escolhacurso = await _context.EscolhaCursos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (escolhacurso == null)
        {
            return NotFound();
        }

        return View(escolhacurso);
    }

    // POST: ESCOLHACURSOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var escolhacurso = await _context.EscolhaCursos.FindAsync(id);
        if (escolhacurso != null)
        {
            _context.EscolhaCursos.Remove(escolhacurso);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EscolhaCursoExists(int? id)
    {
        return _context.EscolhaCursos.Any(e => e.Id == id);
    }
}
