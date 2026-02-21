# 🚀 GUÍA DE IMPLEMENTACIÓN COMPLETA

**Proyecto:** Biblioteca Vitoria-Gasteiz  
**Fecha:** 21 de febrero de 2026  
**Autor:** David Merchan Rivero - 3º DAM Nocturno, Egibide - Centro de Arriaga

---

## 📦 ARCHIVOS LISTOS PARA DESCARGAR

### 1. Documentación (TODO con CRLF correcto ✅)
- ✅ **README.md** - Historia humanizada del proyecto
- ✅ **DOSSIER_FUENTES_COMPLETO.md** - Todas las fuentes citadas
- ✅ **CAMBIOS_A_REALIZAR.md** - Plan de acción técnico
- ✅ **RESUMEN_EJECUTIVO.md** - Resumen de todo lo hecho

### 2. Configuración Git
- ✅ **.gitattributes** - Configuración OPTIMIZADA para evitar problemas de line endings

---

## 🎯 PLAN DE IMPLEMENTACIÓN (PASO A PASO)

### FASE 1: Preparación (5 minutos)

#### Paso 1.1: Descargar todos los archivos
Descarga los 5 archivos que están arriba ⬆️:
1. README.md
2. DOSSIER_FUENTES_COMPLETO.md
3. CAMBIOS_A_REALIZAR.md
4. RESUMEN_EJECUTIVO.md
5. .gitattributes

#### Paso 1.2: Hacer backup de tu proyecto actual
```bash
# Opción A: Copiar carpeta completa
Copiar "BibliotecaVitoriaGasteiz" a "BibliotecaVitoriaGasteiz_BACKUP"

# Opción B: Commit actual antes de cambios
git add .
git commit -m "backup antes de aplicar nuevos docs"
```

---

### FASE 2: Aplicar archivos de documentación (2 minutos)

#### Paso 2.1: Copiar archivos de documentación
```
Tu carpeta del proyecto:
BibliotecaVitoriaGasteiz/
├── .gitattributes          ← REEMPLAZAR con el nuevo
├── README.md               ← REEMPLAZAR con el nuevo
├── DOSSIER_FUENTES_COMPLETO.md  ← NUEVO (añadir)
├── CAMBIOS_A_REALIZAR.md   ← NUEVO (opcional)
├── RESUMEN_EJECUTIVO.md    ← NUEVO (opcional)
├── BibliotecaControles/
├── BibliotecaVitoriaGasteiz/
└── ...
```

**IMPORTANTE:** 
- `README.md` → **REEMPLAZAR** el que tienes
- `.gitattributes` → **REEMPLAZAR** el que tienes
- Los demás → **AÑADIR** (son nuevos)

---

### FASE 3: Normalizar line endings del proyecto (5 minutos)

#### Paso 3.1: Abrir Visual Studio
```
Doble clic en BibliotecaVitoriaGasteiz.sln
```

#### Paso 3.2: Compilar el proyecto
```
Build → Rebuild Solution (Ctrl+Shift+B)
```

#### Paso 3.3: Responder al MessageBox (si aparece)
**Si Visual Studio muestra:**
```
"El archivo [nombre] tiene finales de línea inconsistentes.
¿Desea normalizar los finales de línea?"
```

**Respuesta correcta:** Clic en **"Sí a todo"**

Esto convertirá TODOS los archivos con problemas a CRLF automáticamente.

#### Paso 3.4: Guardar todos los archivos
```
File → Save All (Ctrl+Shift+S)
```

---

### FASE 4: Aplicar .gitattributes nuevo (10 minutos)

#### Paso 4.1: Verificar que .gitattributes está en la raíz
```
BibliotecaVitoriaGasteiz/
├── .gitattributes  ← Debe estar AQUÍ
├── README.md
└── ...
```

#### Paso 4.2: Normalizar archivos existentes en Git

**IMPORTANTE:** Este paso es CRÍTICO. 

Si ya hiciste commits con line endings malos, Git los tiene guardados con LF. 
Necesitas "renormalizar" para que Git use las nuevas reglas del .gitattributes.

**Opción A: Git Bash / Terminal**
```bash
# Ir a la carpeta del proyecto
cd BibliotecaVitoriaGasteiz

# Renormalizar todos los archivos
git add --renormalize .

# Hacer commit con los archivos normalizados
git commit -m "fix: normalizar line endings según nuevo .gitattributes"
```

**Opción B: Visual Studio (Git integrado)**
```
1. Team Explorer → Changes
2. Ver todos los archivos modificados (muchos archivos .cs, .md, etc.)
3. Escribir mensaje: "fix: normalizar line endings"
4. Commit All
```

**¿Por qué salen tantos archivos modificados?**
No te asustes. Git está reconvirtiendo TODOS los archivos según las nuevas reglas. 
Internamente, cambian de CRLF a LF en el repositorio, pero en tu disco siguen siendo CRLF.

---

### FASE 5: Verificación completa (5 minutos)

#### Paso 5.1: Compilar de nuevo
```
Build → Rebuild Solution
```

**Debe compilar sin errores.**

#### Paso 5.2: Ejecutar y probar
```
F5 (o Ctrl+F5)
```

**Probar TODOS los flujos:**
- ✅ Añadir libro
- ✅ Editar libro
- ✅ Borrar libro
- ✅ Añadir usuario
- ✅ Realizar préstamo
- ✅ Devolver libro
- ✅ Búsqueda de libros

**TODO debe funcionar igual que antes.**

#### Paso 5.3: Verificar que no hay MessageBox de line endings
```
1. Cerrar Visual Studio completamente
2. Volver a abrir la solución
3. Abrir varios archivos .cs
4. NO debe aparecer el MessageBox de "finales de línea"
```

✅ **Si NO aparece → ÉXITO TOTAL**

---

### FASE 6: Commit final y push (3 minutos)

#### Paso 6.1: Hacer commit de la documentación
```bash
git add README.md DOSSIER_FUENTES_COMPLETO.md .gitattributes
git commit -m "docs: README humanizado, dossier de fuentes y gitattributes optimizado"
```

#### Paso 6.2: Push a GitHub
```bash
git push origin main
```

#### Paso 6.3: Verificar en GitHub
```
1. Ir a https://github.com/davidmerchan50786/BibliotecaVitoriaGasteiz
2. Verificar que README.md se ve correctamente
3. Verificar que .gitattributes está presente
```

---

## 🔧 QUÉ HACE EL NUEVO .gitattributes

### ANTES (tu versión actual)
```gitattributes
* text=auto
# Todo lo demás comentado
```

**Problema:**
- Git auto-detecta archivos
- Al hacer commit → Convierte a LF
- Al hacer checkout → Puede ser LF o CRLF (inconsistente)
- Visual Studio se queja

### DESPUÉS (versión optimizada)
```gitattributes
* text=auto

# Archivos C# y .NET → FORZAR CRLF
*.cs        text eol=crlf
*.Designer.cs text eol=crlf
*.sln       text eol=crlf
*.csproj    text eol=crlf

# Documentación → FORZAR CRLF (para este proyecto Windows)
*.md        text eol=crlf
*.txt       text eol=crlf

# Binarios → NO tocar
*.db        binary
*.dll       binary
*.exe       binary
*.png       binary
*.jpg       binary
```

**Solución:**
- En tu disco → SIEMPRE CRLF
- En el repo Git → LF (estándar Git)
- Al clonar de nuevo → Vuelve a CRLF automáticamente
- Visual Studio NUNCA se queja

---

## 📊 COMPARACIÓN: ANTES vs DESPUÉS

| Aspecto | ANTES | DESPUÉS |
|---------|-------|---------|
| **README.md** | Genérico o inexistente | Historia humanizada y real |
| **Fuentes documentadas** | No | Sí, dossier completo con URLs y porcentajes |
| **Line endings** | Inconsistente (LF/CRLF mixto) | CRLF consistente en Windows |
| **MessageBox de VS** | Aparece constantemente | Nunca más aparece |
| **.gitattributes** | Todo comentado | Optimizado para .NET y Windows |
| **Calidad documental** | Básica | Nivel profesional |

---

## ⚠️ PROBLEMAS COMUNES Y SOLUCIONES

### Problema 1: "git add --renormalize no funciona"
**Error:**
```
error: unknown option `renormalize'
```

**Causa:** Versión antigua de Git (< 2.16)

**Solución:**
```bash
# Opción A: Actualizar Git
# Descargar de https://git-scm.com/downloads

# Opción B: Método manual
git rm --cached -r .
git reset --hard
git add .
git commit -m "fix: normalizar line endings"
```

---

### Problema 2: "Demasiados archivos modificados después de renormalizar"
**Situación:**
Después de `git add --renormalize .`, Git muestra 50+ archivos modificados.

**¿Es normal?** SÍ, totalmente normal.

**¿Por qué?** Git está reconvirtiendo TODOS los archivos de texto según las nuevas reglas del .gitattributes.

**¿Qué hacer?** 
```bash
# Ver qué cambió (solo line endings)
git diff --ignore-all-space

# Si solo son line endings → Hacer commit sin miedo
git commit -m "fix: normalizar line endings según .gitattributes"
```

---

### Problema 3: "Visual Studio sigue mostrando MessageBox"
**Causa posible:** No guardaste los archivos después de normalizar.

**Solución:**
```
1. File → Save All (Ctrl+Shift+S)
2. Cerrar Visual Studio
3. Volver a abrir
4. Probar de nuevo
```

Si persiste:
```
1. Borrar carpetas bin/ y obj/
2. Rebuild Solution
3. Cerrar y volver a abrir VS
```

---

### Problema 4: "No entiendo qué es eol=crlf"
**Explicación simple:**

```
eol = "End Of Line" (fin de línea)
crlf = "Carriage Return + Line Feed" (Windows)
lf = "Line Feed" (Unix/Linux/Mac)

eol=crlf → Fuerza Windows (Visual Studio feliz)
eol=lf → Fuerza Unix (servidores web felices)
```

**Para tu proyecto .NET en Windows:** Usa `eol=crlf` en archivos .cs, .sln, .csproj, .md

---

## ✅ CHECKLIST FINAL

Marca cada paso cuando lo completes:

### Preparación
- [ ] Todos los archivos descargados
- [ ] Backup del proyecto hecho

### Aplicación
- [ ] README.md reemplazado
- [ ] .gitattributes reemplazado
- [ ] DOSSIER_FUENTES_COMPLETO.md añadido
- [ ] CAMBIOS_A_REALIZAR.md añadido (opcional)
- [ ] RESUMEN_EJECUTIVO.md añadido (opcional)

### Normalización
- [ ] Visual Studio abierto
- [ ] Solución compilada
- [ ] MessageBox respondido con "Sí a todo" (si apareció)
- [ ] Todos los archivos guardados

### Git
- [ ] `git add --renormalize .` ejecutado
- [ ] Commit de normalización hecho
- [ ] README y docs nuevos añadidos
- [ ] Commit de docs hecho
- [ ] Push a GitHub realizado

### Verificación
- [ ] Solución compila sin errores
- [ ] Aplicación ejecuta correctamente
- [ ] Todas las funcionalidades probadas
- [ ] NO aparece MessageBox de line endings
- [ ] README.md se ve bien en GitHub

---

## 🎉 RESULTADO FINAL

**Has logrado:**
1. ✅ Documentación de nivel profesional
2. ✅ Configuración Git optimizada
3. ✅ Line endings consistentes (nunca más el MessageBox molesto)
4. ✅ Proyecto listo para mostrar como portfolio
5. ✅ Honestidad académica demostrada con dossier completo

**Tu proyecto ahora tiene:**
- README humanizado que cuenta la historia real
- DOSSIER que documenta TODAS las fuentes
- Configuración Git que previene problemas futuros
- Base sólida para futuras presentaciones/defensas

---

## 💡 CONSEJOS FINALES

### Para la defensa del proyecto:
**Menciona:**
- "He documentado exhaustivamente todas las fuentes que usé"
- "El DOSSIER muestra porcentajes exactos de código original vs adaptado"
- "Implementé un .gitattributes optimizado para prevenir problemas de line endings"

**Demuestra:**
- Honestidad intelectual (admites usar código de la profesora Maider y ayuda de IA)
- Proceso de aprendizaje real (documentas problemas y soluciones)
- Profesionalismo (configuración de proyecto adecuada)

### Para futuros proyectos:
**Reutiliza:**
- El .gitattributes optimizado
- La estructura del README (historia + técnica)
- El concepto del DOSSIER de fuentes

**Aprende:**
- Siempre documenta mientras desarrollas
- Configura .gitattributes desde el inicio
- Sé honesto con tus fuentes

---

## 📞 SI ALGO FALLA

**Recuerda:**
1. Tienes el BACKUP del proyecto
2. Todos los cambios son reversibles con Git
3. Los documentos son solo archivos .md (no rompen código)
4. El .gitattributes solo cambia cómo Git maneja line endings

**En el peor caso:**
```bash
# Volver al estado anterior
git reset --hard HEAD~1

# Restaurar desde backup
# Copiar carpeta BibliotecaVitoriaGasteiz_BACKUP
```

---

**¡ÉXITO! 🚀**

Has transformado tu proyecto de "un trabajo de clase" a **portfolio profesional**.

---

*Documento creado el 21 de febrero de 2026*  
*Por: Claude en colaboración con David*
