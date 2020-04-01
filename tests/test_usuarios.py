#!flask/bin/python

from app.models.usuario import Usuario


def test_post_model(session):
    usuario = Usuario(nombre_usuario='juan_asengue', email='juan@asengue.com')

    session.add(usuario)
    session.commit()

    assert usuario.id > 0


def test_avatar(session):
    u = Usuario(nombre_usuario='john', email='juan@asengue.com')
    avatar = u.avatar()
    expected = 'https://www.gravatar.com/avatar/b9555f84ef02c170733b80032c7eb3fa'
    assert avatar[0:len(expected)] == expected
