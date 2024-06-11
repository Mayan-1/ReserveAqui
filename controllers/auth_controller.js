
  const { Administrador } = require("../data/dbContext");
const { administradorFacade } = require("../dependecy/injection");
const AdministradorFacade = require("../facade/administrador-facade");
const bcrypt = require("bcryptjs");
const jwt = require("jsonwebtoken");

exports.signup = (req, res) => {
    const nome = req.body.nome;
    const email = req.body.email;
    const senha = req.body.senha;
    const codigo_instituicao_fk = req.body.codigo_instituicao_fk;

    bcrypt
    .hash(senha, 12)
    .then((novaSenha) => {
        administradorFacade.create({nome: nome, email: email, senha: novaSenha, codigo_instituicao_fk: codigo_instituicao_fk});

    }).then((resultado) => {
        res.status(201).json({resultado: "Usuário cadastrado com sucesso!"});
    }).catch((err) => {
        res.status(500);
    });

};

exports.login = (req, res, next) => {
  const email = req.body.email;
  const senha = req.body.senha;

  let usuarioCarregado;

  Administrador.findOne({ where: { email: email } })
    .then((administrador) => {
      if (!administrador) {
        res.status(401).json({ error: "O email informado não foi cadastrado" });
      }

      administradorCarregado = administrador;

      return bcrypt.compare(senha, administrador.senha);
    })
    .then((senhaDescriptografada) => {
      if (!senhaDescriptografada) {
        res.status(401).json({ error: "Usuário ou senha errado!" });
      }

      const token = jwt.sign(
        {
          email: administradorCarregado.email,
        },
        "minha_chave_secreta",
        { expiresIn: "1h" }
      );

      res.status(200).json({ token: token });
    })
    .catch((err) => {
      next(err);
    });
};
