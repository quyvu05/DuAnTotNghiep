const pathNeedLogin = ["account-settings-tab"]

export const isUserLoggedIn = () => !!localStorage.getItem("accessToken")

export const canNavigate = to => {
  return !(!isUserLoggedIn() && pathNeedLogin.includes(to.name))
}
