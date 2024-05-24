
const administrador = require("../data/administrador");
const { administradorFacade } = require("../dependecy/injection");
const AdministradorFacade = require("../facade/administrador-facade");
const bcrypt = require("bcryptjs");


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

exports.login = (req, res) => {
    
}